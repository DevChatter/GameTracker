using System;
using System.Linq;
using System.Linq.Expressions;
using DevChatter.GameTracker.Core.Model;
using Microsoft.EntityFrameworkCore.Internal;

namespace DevChatter.GameTracker.Core.Data.Specifications
{
    /// <summary>
    /// Used for filtering BaseEntity objects based on specified criteria
    /// </summary>
    public class BaseEntityPolicy<T> : ISpecification<T> where T : BaseEntity
    {
        protected BaseEntityPolicy(Expression<Func<T, bool>> criteria)
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

    public class PlayerPolicy : BaseEntityPolicy<Player>
    {
        protected PlayerPolicy(Expression<Func<Player, bool>> criteria) 
            : base(criteria)
        {
        }

        /// <summary>
        /// Gets names similar to the specified criteria.
        /// Ex: "Brend" would find ["Brendan", "Brendon", "Brenden"]
        /// </summary>
        public static PlayerPolicy ByNameLike(string filter)
        {
            string[] searchTerms = filter.ToLowerInvariant().Split(" ",
                StringSplitOptions.RemoveEmptyEntries);
            return new PlayerPolicy(p =>
                searchTerms.All(term => p.FirstName.ToLowerInvariant().StartsWith(term)
                                     || p.LastName.ToLowerInvariant().StartsWith(term)));
        }
    }
}