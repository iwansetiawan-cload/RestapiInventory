using NHibernate;
using NHibernate.Criterion;
using RestapiInventory.Models;

namespace RestapiInventory.Dao
{
    public class PurchaseRequestHeaderDao(NHibernate.ISession _session, ISessionFactory _sessionFactory) : CommonDao<PurchaseRequestHeader>(_session)
    {
        protected NHibernate.ISession session = _session;
        protected ISessionFactory sessionFactory = _sessionFactory;

        public PurchaseRequestHeader GetById(string id)
        {
            using (session = sessionFactory.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria<PurchaseRequestHeader>();
                criteria.Add(Expression.Eq("Id", id));
                return criteria.UniqueResult<PurchaseRequestHeader>();
            }
        }
        public PurchaseRequestHeader GetByNoDocument(string noDocument)
        {
            using (session = sessionFactory.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria<PurchaseRequestHeader>();
                criteria.Add(Expression.Eq("DocumentNumber", noDocument));
                return criteria.UniqueResult<PurchaseRequestHeader>();
            }
        }
    }
}
