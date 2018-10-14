using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEmployee
{
    class Employee : ViewModel
    {
        private int _Id;
        private string _Name;
        private int _Age;
        private decimal _Salary;

        public int Id { get => _Id; set => Set(ref _Id, value); }
        public string Name { get => _Name; set => Set(ref _Name, value); }
        public int Age { get => _Age; set => Set(ref _Age, value); }
        public decimal Salary { get => _Salary; set => Set(ref _Salary, value) ; }
    }
}
