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

namespace EmployeeDatabase
{
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
            conn = new SQLiteConnection(DBFILE, true);
            conn.CreateTable<Employee>();
        }

        #region Public methods
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
        #endregion
    }
}
