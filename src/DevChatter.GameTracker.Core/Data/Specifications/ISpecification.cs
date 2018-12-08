using DevChatter.GameTracker.Core.Model;
using System;
using System.Linq.Expressions;

namespace DevChatter.GameTracker.Core.Data.Specifications
{
    /// <summary>
    /// Interface used to encapsulate filtering logic for use by Repositories
    /// </summary>
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
    }
}