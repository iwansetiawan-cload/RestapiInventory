using NHibernate;
using NHibernate.Criterion;
using RestapiInventory.Models;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace RestapiInventory.Dao
{
   
    public class UserProfileDao(NHibernate.ISession _session, ISessionFactory _sessionFactory) : CommonDao<UserProfile>(_session)
    {
        protected NHibernate.ISession session = _session;
        protected ISessionFactory sessionFactory = _sessionFactory;
        public IList<UserProfile> GetAll()
        {
            using (session = sessionFactory.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria<UserProfile>();
                return criteria.List<UserProfile>();
            }
        }
        public IList<UserProfile> GetByDivision(string division)
        {
       
            using (session = sessionFactory.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria<UserProfile>();
                criteria.Add(Restrictions.Eq("DivisionId", division));
                return criteria.List<UserProfile>();
            }
        }
        public IList<UserProfile> GetByName(string keyword)
        {

            using (session = sessionFactory.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria<UserProfile>();
                criteria.Add(Restrictions.InsensitiveLike("FirstName", keyword ?? "", MatchMode.Anywhere));
                return criteria.List<UserProfile>();
            }
        }
        public UserProfile GetById(string id)
        {
            using (session = sessionFactory.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria<UserProfile>();
                criteria.Add(Restrictions.InsensitiveLike("Id", id));
                return criteria.UniqueResult<UserProfile>();
            }
        }

    }
}
