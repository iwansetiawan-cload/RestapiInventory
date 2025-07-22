using FluentNHibernate.Data;
using NHibernate;
using NHibernate.Criterion;
using RestapiInventory.Dto.Common;
using RestapiInventory.Models;

namespace RestapiInventory.Dao
{
    public class PurchaseRequestDetailDao(NHibernate.ISession _session, ISessionFactory _sessionFactory) : CommonDao<PurchaseRequestDetail>(_session)
    {
        protected NHibernate.ISession session = _session;
        protected ISessionFactory sessionFactory = _sessionFactory;

        public IList<PurchaseRequestDetail> GetByHeaderId(string headerId)
        {
            using (session = sessionFactory.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria<PurchaseRequestDetail>();
                criteria.Add(Restrictions.Eq("PurchaseRequestHeaderId", headerId));
                return criteria.List<PurchaseRequestDetail>();
            }
        }
       

    }
}
