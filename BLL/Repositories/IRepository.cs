using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LearnNetCoreWepAPI.BLL.Repositories
{
    public interface  IRepository<TE> where TE : class
    {
          DbSet<TE> _entities { get; }
        Task Add(TE entity);
        Task AddRange(IEnumerable<TE> entities);
        Task AddRange(List<TE> entities);
        Task<bool> UpdateState(TE entity);
        void UpdateRange(IEnumerable<TE> entities);
        void Remove(TE entity);
        Task<bool> Remove(Expression<Func<TE, bool>> identity, params Expression<Func<TE, object>>[] includes);
        void RemoveRange(IEnumerable<TE> entities);
        Task<int> Count();
        Task<int> Count(Expression<Func<TE, bool>> predicate);
        Task<bool> IsRecordExists(Expression<Func<TE, bool>> predicate);
        Task<bool> IsRecordExists(Expression<Func<TE, bool>> predicate, params Expression<Func<TE, object>>[] includes);
        Task<TE> Get(int id);
        Task<IEnumerable<TE>> GetAll();
        Task<TE> GetSingleOrDefault(Expression<Func<TE, bool>> predicate, params Expression<Func<TE, object>>[] includes);
        Task<IEnumerable<TE>> Find(Expression<Func<TE, bool>> predicate);
        Task<IEnumerable<TE>> Find(Expression<Func<TE, bool>> filter = null,
                                                Func<IQueryable<TE>, IOrderedQueryable<TE>> orderBy = null,
                                                string includeProperties = "");
        Task<List<TE>> GetAll(params Expression<Func<TE, object>>[] includes);

        Task<List<TE>> SearchBy(Expression<Func<TE, bool>> predicate, params Expression<Func<TE, object>>[] includes);
        Task<TE> FindBy(Expression<Func<TE, bool>> predicate, params Expression<Func<TE, object>>[] includes);



          Task<bool> Save();
          int SaveChanges();
    }
}
