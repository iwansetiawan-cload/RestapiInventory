using NHibernate.Criterion;
using NHibernate;
using FluentNHibernate.Data;

namespace RestapiInventory.Dao
{
    public class CommonDao<T>(NHibernate.ISession session) where T : class
    {
        private readonly NHibernate.ISession _session = session;

        public T GetById<T>(object id)
        {
            return _session.Get<T>(id);
        }

        public Task Add(T entity)
        {

            using (ITransaction transaction = _session.BeginTransaction())
            {
                _session.Save(entity);
                transaction.Commit();
            }
            return Task.CompletedTask;
        }
    

        public void Update<T>(T entity)
        {
            using (var transaction = _session.BeginTransaction())
            {
                try
                {
                    // Merge entity ke dalam session
                    var mergedEntity = _session.Merge(entity);

                    // Save or update entitas yang sudah di-merge
                    _session.SaveOrUpdate(mergedEntity);

                    // Commit transaksi
                    transaction.Commit();
                    Console.WriteLine("Entity berhasil di-merge dan di-update.");
                }
                catch (Exception ex)
                {
                    // Rollback jika terjadi kesalahan
                    transaction.Rollback();
                    Console.WriteLine($"Terjadi kesalahan saat merge: {ex.Message}");
                    throw;
                }
            }
        }

        public void Merge(T entity)
        {
            using (var transaction = _session.BeginTransaction())
            {
                try
                {
                    // Merge entity ke dalam session
                    var mergedEntity = _session.Merge(entity);

                    // Save or update entitas yang sudah di-merge
                    _session.SaveOrUpdate(mergedEntity);

                    // Commit transaksi
                    transaction.Commit();
                    Console.WriteLine("Entity berhasil di-merge dan di-update.");
                }
                catch (Exception ex)
                {
                    // Rollback jika terjadi kesalahan
                    transaction.Rollback();
                    Console.WriteLine($"Terjadi kesalahan saat merge: {ex.Message}");
                    throw;
                }
            }
        }

        public void Delete<T>(T entity)
        {
            using ITransaction transaction = _session.BeginTransaction();
            _session.Delete(entity);
            transaction.Commit();
        }       

        public IList<T> FindAll(int currentpage, int pagesize)
        {
            int firstresult = (currentpage - 1) * pagesize;
            ICriteria criteria = session.CreateCriteria<T>();
            criteria.SetFirstResult(firstresult);
            criteria.SetMaxResults(pagesize);
            return criteria.List<T>();
        }
        public int CountAll()
        {
            ICriteria criteria = session.CreateCriteria<T>();
            criteria.SetProjection(Projections.RowCount());
            return criteria.UniqueResult<int>();
        }
    }
}
