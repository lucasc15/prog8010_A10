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
    class DB
    {
        private string DBFILE = "personel.db3";
        private SQLiteConnection conn;
        public DB()
        {
            init();
        }
        private void init()
        {
            conn = new SQLiteConnection("personal.db3", true);
            conn.CreateTable<Employee>();
        }
        public void InsertEmployee(Employee e)
        {
            conn.Insert(e);
        }
        public void UpdateEmployee(Employee e)
        {
            conn.Update(e);
        }
        public List<Employee> GetEmployees()
        {
            List<Employee> employees = conn.Table<Employee>().ToList();
            return employees;
        }
    }
}
