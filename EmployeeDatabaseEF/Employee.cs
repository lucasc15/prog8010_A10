/*
 * Assignment #11
 * Group #1
 */
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;

namespace EmployeeDatabase
{
    public class Employee
    {
        [PrimaryKey, AutoIncrement]
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public decimal Rate { get; set; }
        public Employee(string name, string position, decimal rate)
        {
            Name = name;
            Position = position;
            Rate = rate;
        }
        public Employee() { }
    }
    
}
