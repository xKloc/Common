﻿using Kloc.Common.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Data.EntityFrameworkCore
{
    /// <summary>
    /// Standard repository implementation.
    /// </summary>
    /// <typeparam name="TAggregateRoot">The <see cref="IAggregateRoot"/> represented in the database.</typeparam>
    public abstract class Repository<TAggregateRoot> : ReadOnlyRepository<TAggregateRoot>, IRepository<TAggregateRoot>
        where TAggregateRoot : class, IAggregateRoot
    {
        /// <summary>
        /// Constucts a <see cref="Repository{T}"/> from a <see cref="DbSet{TEntity}"/>.
        /// </summary>
        /// <param name="dbSet">The <see cref="DbSet{TEntity}"/>.</param>
        public Repository(DbSet<TAggregateRoot> dbSet) : base(dbSet) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<TAggregateRoot> GetByIdAsync(Guid id)
        {
            return _dbSet.FindAsync(id);
        }

        /// <summary>
        /// Adds the <see cref="IAggregateRoot"/> represented to the database.
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Add(TAggregateRoot entity)
        {
            _dbSet.Add(entity);
        }

        /// <summary>
        /// Removes the <see cref="IAggregateRoot"/> represented from the database.
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Remove(TAggregateRoot entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
