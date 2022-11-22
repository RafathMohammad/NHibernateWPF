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
