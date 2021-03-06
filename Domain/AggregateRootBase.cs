﻿using Kloc.Common.Excepting;
using System;
using System.Collections.Generic;

namespace Kloc.Common.Domain
{
    /// <summary>
    /// Base class for an <see cref="IAggregateRoot"/> implementation.
    /// </summary>
    public abstract class AggregateRootBase : AggregateRootBase<Guid>, IAggregateRoot<Guid>
    {
        private readonly HashSet<IDomainEvent> domainEvents = new HashSet<IDomainEvent>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        protected AggregateRootBase(Guid id) : base(id)
        {
            Guard.ForDefault(id, nameof(id));
        }

        /// <summary>
        /// Compares this entity to another.
        /// </summary>
        /// <param name="obj">The entity to compare.</param>
        /// <returns>True if both references or keys are equal.</returns>
        public override bool Equals(object obj)
        {
            var other = obj as AggregateRootBase;

            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetType() != other.GetType())
                return false;

            return Id.Equals(other.Id);
        }

        /// <summary>
        /// Compares two entities.
        /// </summary>
        /// <param name="a">The first entity to compare.</param>
        /// <param name="b">The second entity to compare.</param>
        /// <returns>True if equal.</returns>
        public static bool operator ==(AggregateRootBase a, AggregateRootBase b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        /// <summary>
        /// Compares two entities.
        /// </summary>
        /// <param name="a">The first entity to compare.</param>
        /// <param name="b">The second entity to compare.</param>
        /// <returns>True if not equal.</returns>
        public static bool operator !=(AggregateRootBase a, AggregateRootBase b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Gets the hash code for the entity.
        /// </summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode()
        {
            return (GetType().ToString() + Id.ToString()).GetHashCode();
        }
    }
}
