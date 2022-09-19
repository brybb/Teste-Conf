using System;
using System.Collections.Generic;
using System.Text;
using Confitec.Application.Interfaces;
using Confitec.Data;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Confitec.Data
{
    /// <summary>
    ///     Repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public class Repository<T, TKey> : IDisposable, IRepository<T, TKey> where T : class
    {
        private readonly Context _context;

        public Repository(Context context)
        {
            _context = context;
        }

        /// <summary>
        ///     List all of <see cref="IQueryable{T}" />
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> All()
        {
            return _context.Set<T>();
        }

        /// <summary>
        ///     Find by predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>
        ///     <see cref="IQueryable{T}" />
        /// </returns>
        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            var query = _context.Set<T>().Where(predicate);
            return query;
        }

        /// <summary>
        ///     Get single object
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        public T Single(TKey id)
        {
            return _context.Set<T>().Find(id);
        }

        /// <summary>
        ///     Add entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        /// <summary>
        ///     Delete entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        /// <summary>
        ///     Update entity
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
