using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfEmployee
{
    class MainWindowViewModel : ViewModel
    {
        const string connection_string = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employees;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public ICommand AddCommand { get; }
        public ICommand RemoveCommand { get; }
        public ICommand EditCommand { get; }
        private SqlDataAdapter _Adapter;
        public DataTable Dt { get; set; }
        public DataRowView SelectedEmployee { get; set; }

        public MainWindowViewModel()
        {
            using (var connection = new SqlConnection(connection_string))
            {
                AddCommand = new LambdaCommand(OnAddCommandExecuted);
                RemoveCommand = new LambdaCommand(OnRemoveCommandExecuted);
                EditCommand = new LambdaCommand(OnEditCommandExecuted);
                _Adapter = new SqlDataAdapter();
                Dt = new DataTable();
                SqlCommand command = new SqlCommand("SELECT * FROM Employees", connection);
                _Adapter.SelectCommand = command;
                _Adapter.Fill(Dt);
            }

        }

        private void OnEditCommandExecuted(object obj)
        {
            using (var connection = new SqlConnection(connection_string))
            {
                var command = new SqlCommand(@"UPDATE Employees 
            SET Name = @Name, Age = @Age, Salary = @Salary 
            WHERE Id = @Id", connection);
                command.Parameters.Add("@FIO", SqlDbType.NVarChar, -1, "FIO");
                command.Parameters.Add("@Birthday", SqlDbType.NVarChar, -1, "Birthday");
                command.Parameters.Add("@Email", SqlDbType.NVarChar, 100, "Email");
                command.Parameters.Add("@Phone", SqlDbType.NVarChar, -1, "Phone");
                command.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");
                _Adapter.UpdateCommand = command;
                SelectedEmployee.BeginEdit();
                EmployeeWindow editWindow = new EmployeeWindow(SelectedEmployee.Row);
                editWindow.ShowDialog();
                if (editWindow.DialogResult.HasValue && editWindow.DialogResult.Value)
                {
                    SelectedEmployee.EndEdit();
                    _Adapter.Update(Dt);
                }
                else
                {
                    SelectedEmployee.CancelEdit();
                }
            }

        }
        private void OnRemoveCommandExecuted(object obj)
        {
            using (var connection = new SqlConnection(connection_string))
            {
                var command = new SqlCommand(@"DELETE FROM Employees WHERE Id = @Id", connection);
                command.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
                _Adapter.DeleteCommand = command;
                SelectedEmployee.BeginEdit();
                Dt.Rows.Remove(SelectedEmployee.Row);
                SelectedEmployee.EndEdit();
                _Adapter.Update(Dt);
            }
        }


        private void OnAddCommandExecuted(object obj)
        {
            using (var connection = new SqlConnection(connection_string))
            {
                var command = new SqlCommand(@"INSERT INTO Employees (Name, Age, Salary) 
                                        VALUES (@Name, @Age, @Salary);
                                        SET @Id = @@IDENTITY;", connection);
                command.Parameters.Add("@Name", SqlDbType.NVarChar, -1, "Name");
                command.Parameters.Add("@Age", SqlDbType.NVarChar, -1, "Age");
                command.Parameters.Add("@Salary", SqlDbType.NVarChar, 100, "Salary");
                command.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
                _Adapter.InsertCommand = command;
                DataRow newRow = Dt.NewRow();
                EmployeeWindow employeeWindow = new EmployeeWindow(newRow);
                employeeWindow.ShowDialog();
                if (employeeWindow.DialogResult.HasValue && employeeWindow.DialogResult.Value)
                {
                    Dt.Rows.Add(employeeWindow.ResultRow);
                    _Adapter.Update(Dt);
                }
            }
        }
    }
}
