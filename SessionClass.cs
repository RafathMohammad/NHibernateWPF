using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using NHibernate;
using NHibernate.Cfg;

namespace NHibernateWPF
{
    public class SessionClass
    {
        public static ISession OpenSession()
        {
            var configuration = new Configuration();
            configuration.Configure();
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}
