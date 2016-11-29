using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDatabase
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public decimal Rate { get; set; }
        public Employee(int id, string name, string position, decimal rate)
        {
            EmployeeID = id;
            Name = name;
            Position = position;
            Rate = rate;
        }
    }
}
