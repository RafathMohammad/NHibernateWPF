using NHibernate;
using System;
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
        }

        private Employee AddEmployee()
        {
            Employee emp = new Employee();
            //emp.EmpId = Convert.ToInt32(EmpId.Text);
            emp.Name = Name.Text;
            emp.JoiningDate = Convert.ToDateTime(JoiningDate.Text);
            emp.Email = EmailId.Text;
            emp.MobileNumber = MobileNumber.Text;
            emp.QLId = QLId.Text;
            return emp;
        }

        private void Update_Button(object sender, RoutedEventArgs e)
        {
            Employee emp = new Employee();
            ISession session = SessionClass.OpenSession();
            session.Update(emp);
            MessageBox.Show("Employee Details have been added");
        }
        private void Add_Button(object sender, RoutedEventArgs e)
        {
            Employee emp = AddEmployee();
            ISession session = SessionClass.OpenSession();
            session.Save(emp);
            MessageBox.Show("Employee Details have been added");
        }

        private void Delete_Button(object sender, RoutedEventArgs e)
        {
            Employee emp = AddEmployee();
            ISession session = SessionClass.OpenSession();
            session.Delete(emp);
            MessageBox.Show("Employee Details have been deleted");
        }
    }
}
