using System;
using System.Collections.Generic;
using System.Text;

namespace NHibernateWPF
{
    public class Employee
    {
        public virtual int EmpId { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime JoiningDate { get; set; }
        public virtual string Email { get; set; }
        public virtual int MobileNumber { get; set; }
    }
}
