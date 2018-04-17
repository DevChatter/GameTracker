using DevChatter.GameTracker.Core.Data;
using DevChatter.GameTracker.Core.Data.Specifications;
using DevChatter.GameTracker.Core.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DevChatter.GameTracker.Data.Ef
{
    public class EfCoreRepository : IRepository
    {
        private readonly ApplicationDbContext _db;

        public EfCoreRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public T Single<T>(ISpecification<T> spec) where T : BaseEntity
        {
            return _db.Set<T>().SingleOrDefault(spec.Criteria);
        }

        public List<T> List<T>(ISpecification<T> spec = null) where T : BaseEntity
        {
            DbSet<T> dbSet = _db.Set<T>();
            return spec != null ? dbSet.Where(spec.Criteria).ToList() : dbSet.ToList();
        }

        public T Create<T>(T dataItem) where T : BaseEntity
        {
            _db.Set<T>().Add(dataItem);
            _db.SaveChanges();

            return dataItem;
        }

        public T Update<T>(T dataItem) where T : BaseEntity
        {
            // do we need this? //_context.Attach(Game).State = EntityState.Modified;
            _db.Set<T>().Update(dataItem);
            _db.SaveChanges();

            return dataItem;
        }

        public void Remove<T>(T dataItem) where T : BaseEntity
        {
            _db.Set<T>().Remove(dataItem);
            _db.SaveChanges();
        }
    }
}