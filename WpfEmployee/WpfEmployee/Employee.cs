using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfEmployee
{
    class Employee : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get; set; }
        public int Age { get; set; }
        private decimal f_Salary;

        public decimal Salary
        {
            get => f_Salary;
            set
            {
                if (Equals(f_Salary, value)) return;
                f_Salary = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Salary)));
            }
        }

    }
}
