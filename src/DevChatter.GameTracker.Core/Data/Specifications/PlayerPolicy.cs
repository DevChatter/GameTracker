using System;
using System.Linq;
using System.Linq.Expressions;
using DevChatter.GameTracker.Core.Model;

namespace DevChatter.GameTracker.Core.Data.Specifications
{
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