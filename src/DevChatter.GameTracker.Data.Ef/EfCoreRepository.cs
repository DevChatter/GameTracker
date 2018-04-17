using System.Collections.Generic;
using DevChatter.GameTracker.Core.Data;
using DevChatter.GameTracker.Core.Data.Specifications;
using DevChatter.GameTracker.Core.Model;

namespace DevChatter.GameTracker.Data.Ef
{
    public class EfCoreRepository : IRepository
    {

        public T Single<T>(ISpecification<T> spec) where T : BaseEntity
        {
            throw new System.NotImplementedException();
        }

        public List<T> List<T>(ISpecification<T> spec = null) where T : BaseEntity
        {
            throw new System.NotImplementedException();
        }

        public T Create<T>(T dataItem) where T : BaseEntity
        {
            throw new System.NotImplementedException();
        }

        public T Update<T>(T dataItem) where T : BaseEntity
        {
            throw new System.NotImplementedException();
        }

        public void Remove<T>(T dataItem) where T : BaseEntity
        {
            throw new System.NotImplementedException();
        }
    }
}