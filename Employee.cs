using System;
using System.Collections.Generic;
using System.Text;

namespace NHibernateWPF
{
    public class Employee
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime JoiningDate { get; set; }
        public virtual string Email { get; set; }
        public virtual string MobileNumber { get; set; }
        public virtual string QLId { get; set; }
    }
}
