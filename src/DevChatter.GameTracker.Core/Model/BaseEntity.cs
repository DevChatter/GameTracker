using System;

namespace DevChatter.GameTracker.Core.Model
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
    }
}