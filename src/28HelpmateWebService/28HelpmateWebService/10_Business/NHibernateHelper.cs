using NHibernate;
using NHibernate.Cfg;

namespace Business
{
    public class NHibernateHelper
    {
        private static ISessionFactory m_SessionFactory;

        public NHibernateHelper()
        {
            m_SessionFactory = GetSessionFactory();
        }

        private static ISessionFactory GetSessionFactory()
        {
            return (new Configuration()).Configure().BuildSessionFactory();
        }

        public static ISession GetSession()
        {
            if(m_SessionFactory==null)
            {
                m_SessionFactory = GetSessionFactory();
            }
            return m_SessionFactory.OpenSession();
        }
    }
}
