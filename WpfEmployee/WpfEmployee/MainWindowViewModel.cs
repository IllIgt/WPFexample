using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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


        public ObservableCollection<Employee> Employees => new ObservableCollection<Employee>
        {
            new Employee {Id = 0, Name = "Danilin", Age = 27, Salary = 50000 },
            new Employee {Id = 1, Name = "Zubkov", Age = 20, Salary = 20000 },
            new Employee {Id = 2, Name = "Budilin", Age = 25, Salary = 90000 }
        };

        public ICommand AddCommand { get; }
        public ICommand RemoveCommand { get; }
        public ICommand EditCommand { get; }
        private SqlConnection _Connection;

        public MainWindowViewModel()
        {
            AddCommand = new LambdaCommand(OnAddCommandExecuted);
            RemoveCommand = new LambdaCommand(OnRemoveCommandExecuted);
            EditCommand = new LambdaCommand(OnEditCommandExecuted);

            using (_Connection = new SqlConnection(connection_string))
            {
                _Connection.Open();
            }
        }

        private void OnEditCommandExecuted(object obj)
        {
            MessageBox.Show("Команда редактирования");
        }
        private void OnRemoveCommandExecuted(object obj)
        {
            MessageBox.Show("Команда удаления");
        }
        private void OnAddCommandExecuted(object obj)
        {
            var command = new SqlCommand($"INSERT INTO Employees (Name, Age, Salary)", _Connection);
            command.ExecuteScalar();
        }
    }
}
