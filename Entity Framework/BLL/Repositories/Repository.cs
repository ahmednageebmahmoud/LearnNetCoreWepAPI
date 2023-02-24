using LearnNetCoreWepAPI.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LearnNetCoreWepAPI.BLL.Repositories
{
    public class Repository<TE> : IRepository<TE> where TE : class
    {
        protected   ApplicationDBContext _context { get; }
        public   DbSet<TE> _entities { get; }

 
        public Repository(ApplicationDBContext context)
        {
            _context = context;
            _entities = context.Set<TE>();
        }


        public async virtual Task Add(TE entity)
        {

            try
            {

                await _entities.AddAsync(entity);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

  

        public async virtual Task AddRange(IEnumerable<TE> entities)
        {
            await _entities.AddRangeAsync(entities);
        }

        public async virtual Task AddRange(List<TE> entities)
        {
            await _entities.AddRangeAsync(entities);
        }

        public virtual async Task<bool> UpdateState(TE entity)
        {
            try
            {
                _entities.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }

        public virtual void UpdateRange(IEnumerable<TE> entities)
        {
            _entities.UpdateRange(entities);
        }

        public virtual void Remove(TE entity)
        {
            _entities.Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<TE> entities)
        {
            _entities.RemoveRange(entities);
        }

        public async virtual Task<int> Count()
        {
            return await _entities.CountAsync();
        }

        public async virtual Task<int> Count(Expression<Func<TE, bool>> predicate)
        {
            return await _entities.Where(predicate).CountAsync();
        }

        public async virtual Task<bool> IsRecordExists(Expression<Func<TE, bool>> predicate)
        {
            return await _entities.IgnoreQueryFilters().CountAsync(predicate) > 0;

        }

        public async virtual Task<bool> IsRecordExists(Expression<Func<TE, bool>> predicate, params Expression<Func<TE, object>>[] includes)
        {
            IQueryable<TE> query = _entities;
            foreach (var includeExpression in includes)
                query = query.Include(includeExpression);
            return await query.IgnoreQueryFilters().CountAsync(predicate) > 0;
        }

        public async virtual Task<TE> Get(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async virtual Task<IEnumerable<TE>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async virtual Task<TE> GetSingleOrDefault(Expression<Func<TE, bool>> predicate, params Expression<Func<TE, object>>[] includes)
        {
            IQueryable<TE> query = _entities;
            foreach (var includeExpression in includes)
                query = query.Include(includeExpression);
            return await query.SingleOrDefaultAsync(predicate);
        }

        public async virtual Task<IEnumerable<TE>> Find(Expression<Func<TE, bool>> predicate)
        {
            return await _entities.Where(predicate).ToListAsync<TE>();
        }

        public async virtual Task<IEnumerable<TE>> Find(Expression<Func<TE, bool>> filter = null,
                                                Func<IQueryable<TE>, IOrderedQueryable<TE>> orderBy = null,
                                                string includeProperties = "")
        {
            IQueryable<TE> query = _entities;
            if (filter != null)
                query = query.Where(filter);

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);

            if (orderBy != null)
                return await orderBy(query).ToListAsync();
            else
                return await query.ToListAsync();
        }




        public virtual async Task<List<TE>> GetAll(params Expression<Func<TE, object>>[] includes)
        {
            var result = _entities.Where(i => true);
            foreach (var includeExpression in includes)
                result = result.Include(includeExpression);
            return await result.ToListAsync();
        }


        public virtual async Task<List<TE>> SearchBy(Expression<Func<TE, bool>> searchBy, params Expression<Func<TE, object>>[] includes)
        {
            var result = _entities.Where(searchBy);
            foreach (var includeExpression in includes)
                result = result.Include(includeExpression);
            return await result.ToListAsync();
        }

     

        /// <summary>
        /// Finds by predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="includes">The includes.</param>
        /// <returns></returns>
        public virtual async Task<TE> FindBy(Expression<Func<TE, bool>> predicate, params Expression<Func<TE, object>>[] includes)
        {
            var result = _entities.Where(predicate);

            foreach (var includeExpression in includes)
                result = result.Include(includeExpression);

            return await result.FirstOrDefaultAsync();
        }

        public virtual async Task<bool> Remove(Expression<Func<TE, bool>> identity, params Expression<Func<TE, object>>[] includes)
        {
            var results = _entities.Where(identity);

            foreach (var includeExpression in includes)
                results = results.Include(includeExpression);
            try
            {
                _entities.RemoveRange(results);
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> Save() => await _context.SaveChangesAsync() > 0;
        public int SaveChanges() => _context.SaveChanges();

    }

}
 