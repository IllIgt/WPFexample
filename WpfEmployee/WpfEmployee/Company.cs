using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEmployee
{
    class Company
    {
        private ObservableCollection<Department> _Departments = new ObservableCollection<Department>();
        private ObservableCollection<Employee> _Employees = new ObservableCollection<Employee>();

        public string Name { get; set; }

        public IEnumerable<Department> Departments => _Departments;
        public IEnumerable<Employee> Employees => _Employees;
        private ObservableCollection<Employee> _SDEmployees = new ObservableCollection<Employee> {
                new Employee { Name = "Danilin", Age = 27, Salary = 50000 },
                new Employee { Name = "Zubkov", Age = 20, Salary = 20000 },
                new Employee { Name = "Budilin", Age = 25, Salary = 90000 }
        };
        private ObservableCollection<Employee> _FinEmployees = new ObservableCollection<Employee> {
                new Employee { Name = "Zolotova", Age = 30, Salary = 90000 },
                new Employee { Name = "Prokhorov", Age = 40, Salary = 40000 }

        };
        private ObservableCollection<Employee> _SAEmployees = new ObservableCollection<Employee> {
                new Employee { Name = "Sucharev", Age = 32, Salary = 90000 }
        };
        private void AddCompanyEmployees(ObservableCollection<Employee> employees)
        {
            foreach (Employee employee in employees)
                _Employees.Add(employee);
        }

        public Company()
        {
            _Departments.Add(new Department(_SDEmployees) { Name = "Software Development" });
            AddCompanyEmployees(_SDEmployees);
            _Departments.Add(new Department(_FinEmployees){ Name = "Finance" });
            AddCompanyEmployees(_FinEmployees);
            _Departments.Add(new Department(_SAEmployees){ Name = "System Administration" });
            AddCompanyEmployees(_SAEmployees);
        }
    }
}
