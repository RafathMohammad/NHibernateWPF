using NHibernate;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            emp.EmpId = Convert.ToInt32(EmpId.Text);
            emp.Name = Name.Text;
            emp.JoiningDate = Convert.ToDateTime(JoiningDate.Text);
            emp.Email = EmailId.Text;
            emp.MobileNumber = Convert.ToInt32(MobileNumber.Text);
            
            return emp;
        }

        private void Update_Button(object sender, RoutedEventArgs e)
        {
            Employee emp = new Employee();
            ISession session = SessionClass.OpenSession();
            session.Update(emp);

        }
        private void Add_Button(object sender, RoutedEventArgs e)
        {
            Employee emp = AddEmployee();
            ISession session = SessionClass.OpenSession();
            session.Save(emp);
        }

        private void Delete_Button(object sender, RoutedEventArgs e)
        {
            NHibernate.Cfg.Configuration cfg = new NHibernate.Cfg.Configuration();
            cfg.AddAssembly("Wpf with Nhibernate Project");
            ISessionFactory factory = cfg.BuildSessionFactory();
            ISession session = factory.OpenSession();
            Employee emp = new Employee();
            emp.EmpId = Convert.ToInt32(EmpId.Text);
            emp.Name = Name.Text;
            emp.JoiningDate = Convert.ToDateTime(JoiningDate.Text);
            emp.Email = EmailId.Text;
            emp.MobileNumber = Convert.ToInt32(MobileNumber.Text);
            session.Delete(emp);

        }
    }
}
