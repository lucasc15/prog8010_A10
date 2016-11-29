using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EmployeeDatabase
{
    /// <summary>
    /// Interaction logic for EmployeeDetail.xaml
    /// </summary>
    public partial class EmployeeDetail : Window
    {
        public event Action<Employee> UpdateData;
        private EmployeeVM employeeDetail;
        public EmployeeDetail(Employee e)
        {
            employeeDetail = new EmployeeVM();
            employeeDetail.CurrentEmployee = e;
            DataContext = employeeDetail;
            InitializeComponent();    
        }
        private void updateEmployee(object sender, RoutedEventArgs e)
        {
            UpdateData(employeeDetail.CurrentEmployee);

        }
    }
    class EmployeeVM: ObservableObject
    {
        private Employee currentEmployee;
        public Employee CurrentEmployee
        {
            get { return currentEmployee; }
            set { currentEmployee = value; }
        }
        public int ID
        {
            get { return currentEmployee.EmployeeID; }
        }
        public string Name
        {
            get { return currentEmployee.Name; }
            set { currentEmployee.Name = value; OnPropertyChanged(); }
        }
        public string Position
        {
            get { return currentEmployee.Position; }
            set { currentEmployee.Position = value;  OnPropertyChanged(); }
        }
        public decimal Rate
        {
            get { return currentEmployee.Rate; }
            set { currentEmployee.Rate = value; OnPropertyChanged(); }
        }
    }
}
