using System;
using System.Linq.Expressions;
using DevChatter.GameTracker.Core.Model;

namespace DevChatter.GameTracker.Core.Data.Specifications
{
    public class BaseEntityPolicy<T> : ISpecification<T> where T : BaseEntity
    {
        public BaseEntityPolicy(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public static BaseEntityPolicy<T> All()
        {
            return new BaseEntityPolicy<T>(x => true);
        }

        public static BaseEntityPolicy<T> ById(Guid id)
        {
            return new BaseEntityPolicy<T>(x => x.Id == id);
        }

        public Expression<Func<T, bool>> Criteria { get; }
    }
}