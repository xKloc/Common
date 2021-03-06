﻿using Kloc.Common.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Kloc.Common.Data.EntityFrameworkCore
{
    /// <summary>
    /// Repository that is read-only and doesn't have a primary key.
    /// </summary>
    /// <typeparam name="TEntity">The type being represented in the database.</typeparam>
    public abstract class ReadOnlyRepositoryBase<TEntity> : IReadOnlyRepository<TEntity> 
        where TEntity : class, IEntity
    {
        /// <summary>
        /// The <see cref="DbSet{TEntity}"/> used to fetch data.
        /// </summary>
        protected readonly DbSet<TEntity> _dbSet;

        /// <summary>
        /// Constructs a new <see cref="ReadOnlyRepositoryBase{T}"/> from the <see cref="DbSet{TEntity}"/>.
        /// </summary>
        /// <param name="dbSet">The <see cref="DbSet{TEntity}"/>.</param>
        public ReadOnlyRepositoryBase(DbSet<TEntity> dbSet)
        {
            _dbSet = dbSet;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual Task<TEntity> GetByIdAsync(params object[] id)
        {
            return _dbSet.FindAsync(id);
        }

        /// <summary>
        /// Gets the <see cref="DbSet{TEntity}"/> as an <see cref="IQueryable{T}"/>.
        /// </summary>
        /// <returns>The <see cref="IQueryable{T}"/>.</returns>
        public IQueryable<TEntity> Query()
        {
            return _dbSet.AsQueryable();
        }
    }
}
