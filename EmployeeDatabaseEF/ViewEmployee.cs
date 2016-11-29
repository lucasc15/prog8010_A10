using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDatabase
{
    class ViewEmployee: ObservableObject
    {
        private EmployeeDatabaseSQLite db;
        private ObservableCollection<Employee> employees;
        public ObservableCollection<Employee> Employees
        {
            get { return employees; }
            set { employees = value; OnPropertyChanged(); }
        }
        public ViewEmployee()
        {
            db = new EmployeeDatabaseSQLite();
            Employees = new ObservableCollection<Employee>(db.GetEmployees());
            if (Employees.Count() <= 0)
            {
                insertBaseEmployeeData();
                Employees = new ObservableCollection<Employee>(db.GetEmployees());
            }
        }
        private Employee selectedEmployee;
        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set { selectedEmployee = value; OnPropertyChanged(); }
        }
        public void UpdateEmployee(Employee e)
        {
            for (int i = 0; i < employees.Count(); i ++)
            {
                if (employees[i].EmployeeID == e.EmployeeID)
                {
                    Employees.RemoveAt(i);
                    Employees.Insert(i, e);
                }
            }
            db.UpdateEmployee(e);
        }
        private void insertBaseEmployeeData()
        {
            List<string> names = new List<string> { "Jerry", "Tom", "Alison", "Alicia", "Mark" };
            List<string> positions = new List<string> { "Janitor", "Salesperson", "Manager", "Developer", "CEO" };
            List<decimal> rates = new List<decimal> { (decimal)10.0, (decimal)15.0, (decimal)25.0, (decimal)25.0, (decimal)35.0 };
            for (int i = 0; i < names.Count(); i++)
            {
                db.InsertEmployee(names[i], positions[i], rates[i]);
            }
        }
    }
}
