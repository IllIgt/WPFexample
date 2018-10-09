using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEmployee
{
    class Department
    {
        private ObservableCollection<Employee> _Employees = new ObservableCollection<Employee>();

        public string Name { get; set; }

        public IEnumerable<Employee> Employees => _Employees;

        public Department()
        {
            _Employees.Add(new Employee { Name = "Danilin", Age = 27, Salary = 50000 });
            _Employees.Add(new Employee { Name = "Zubkov", Age = 23, Salary = 30000 });
            _Employees.Add(new Employee { Name = "Aleksandrov", Age = 30, Salary = 90000 });
        }
    }
}
