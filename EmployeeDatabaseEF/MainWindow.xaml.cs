using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EmployeeDatabase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewEmployee employeeVM;
        EmployeeDetail editWindow;
        public MainWindow()
        {
            InitializeComponent();
            employeeVM = new ViewEmployee();
            DataContext = employeeVM;
        }
        private void editEmployee(object sender, RoutedEventArgs e)
        {
            changeSelected();
            editWindow = new EmployeeDetail(employeeVM.SelectedEmployee);
            editWindow.Show();
            editWindow.UpdateData += value => updateEmployee(value);
        }
        private void updateEmployee(Employee e)
        {
            editWindow.Close();
            if (e != null)
            {
                employeeVM.UpdateEmployee(e);
            }
        }
        private void changeSelected()
        {
            if (EmployeeListView.SelectedItems.Count > 0)
            {
                Employee emp = (Employee)EmployeeListView.SelectedItems[0];
                employeeVM.SelectedEmployee = emp;
            }
        }
    }
}
