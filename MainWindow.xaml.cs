using NHibernate;
using System;
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
                emp.Id = employee.Id;
                session.Update(emp);
                transaction.Commit();
                GetAllEmployees();
                MessageBox.Show("Employee Details have been Updated");
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
                session.Save(emp);
                GetAllEmployees();
                MessageBox.Show("Employee Details have been added");
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
                var Employee = EmployeeGrid.SelectedItem;
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

    }
}
