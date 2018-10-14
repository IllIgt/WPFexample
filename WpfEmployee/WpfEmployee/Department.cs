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

        public Department() { }

        public Department(ObservableCollection<Employee> employees)
        {
            foreach(Employee employee in employees)
                _Employees.Add(employee);
        }
    }
}
