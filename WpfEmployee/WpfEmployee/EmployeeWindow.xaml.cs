
using System.Data;
using System.Windows;

namespace WpfEmployee
{
    public partial class EmployeeWindow : Window
    {
        public DataRow ResultRow { get; set; }
        public EmployeeWindow(DataRow dataRow)
        {
            InitializeComponent();
            ResultRow = dataRow;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fIOTextBox.Text = ResultRow["Name"].ToString();
            birthdayTextBox.Text = ResultRow["Age"].ToString();
            salaryTextBox.Text = ResultRow["Salary"].ToString();
        }
        private void OnSaveButtonClick(object sender, RoutedEventArgs e)
        {
            ResultRow["Name"] = fIOTextBox.Text;
            ResultRow["Age"] = birthdayTextBox.Text;
            ResultRow["Salary"] = salaryTextBox.Text;
            DialogResult = true;
        }
        private void OnCancelButtonClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
