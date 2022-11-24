using NHibernate;
using System;
using System.Globalization;
using System.Linq;
using System.Windows;

namespace NHibernateWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ISession session = SessionClass.OpenSession();
            GetAllEmployees();
            Update.IsEnabled = false;
        }

        private Employee AddEmployee()
        {
            Employee emp = new Employee();
            emp.Name = Name.Text;
            emp.JoiningDate = JoiningDate.Text;
            emp.Email = EmailId.Text;
            emp.MobileNumber = MobileNumber.Text;
            emp.QLId = QLId.Text;
            return emp;
        }
        private void GetAllEmployees()
        {
            try
            {
                ISession session = SessionClass.OpenSession();
                var EmployeeList = session.Query<Employee>().ToList();
                EmployeeGrid.ItemsSource = EmployeeList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DisplayEmployee(Employee emp)
        {
            try
            {
                QLId.Text = emp.QLId;
                Name.Text = emp.Name;
                JoiningDate.Text = emp.JoiningDate; 
                EmailId.Text = emp.Email;
                MobileNumber.Text = emp.MobileNumber;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Update_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                ISession session = SessionClass.OpenSession();
                ITransaction transaction = session.BeginTransaction();
                Employee employee = EmployeeGrid.SelectedItem as Employee;
                Employee emp=AddEmployee();
                if (employee == null)
                {
                    MessageBox.Show("Cannot update the details which are not added, please add the details first");
                }
                else if (emp.Name == "" && emp.QLId == "" && emp.JoiningDate == "" && emp.MobileNumber == "" && emp.Email == "")
                {
                    MessageBox.Show("Please enter the Details to Update");
                }
                else if (emp.Name == employee.Name && emp.QLId == employee.QLId && DateTime.Parse(emp.JoiningDate, CultureInfo.InvariantCulture) == DateTime.Parse(employee.JoiningDate, CultureInfo.InvariantCulture) && emp.MobileNumber == employee.MobileNumber && emp.Email == employee.Email)
                {
                    MessageBox.Show("Employee details are already upto date, No changes added");
                }
                else
                {
                    emp.Id = employee.Id;
                    session.Update(emp);
                    transaction.Commit();
                    Clear_all();
                    Add.IsEnabled = true;
                    GetAllEmployees();
                    MessageBox.Show("Employee Details have been Updated");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Add_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                Employee emp = AddEmployee();
                ISession session = SessionClass.OpenSession();
                if (emp.Name == "" && emp.QLId == "" && emp.JoiningDate == "" && emp.MobileNumber == "" && emp.Email == "")
                {
                    MessageBox.Show("Please enter the Details to add");
                }
                else
                {
                    session.Save(emp);
                    Clear_all();
                    GetAllEmployees();
                    MessageBox.Show("Employee Details have been added");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
         private void Edit_Button(object sender, RoutedEventArgs e)
         {
            try
            {
                Update.IsEnabled = true;
                var Employee = EmployeeGrid.SelectedItem;
                Add.IsEnabled = false;
                DisplayEmployee(Employee as Employee);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Delete_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                var Employee = EmployeeGrid.SelectedItem as Employee;
                ISession session = SessionClass.OpenSession();
                ITransaction transaction = session.BeginTransaction();
                session.Delete(Employee);
                transaction.Commit();
                GetAllEmployees();
                MessageBox.Show("Employee Details have been deleted");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Clear_all()
        {
            try
            {
                Name.Text = "";
                QLId.Text = "";
                EmailId.Text = "";
                MobileNumber.Text = "";
                JoiningDate.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
