using Microsoft.EntityFrameworkCore;
using Sharada.StudentMgt.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sharada.StudentMgt.Core.Helpers
{
    public class EfRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        protected readonly StudentContext _dbContext;

        public EfRepository(StudentContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(Expression<Func<T, bool>> criteria)
        {
            return await ApplySpecification(criteria).ToListAsync();
        }

        private IQueryable<T> ApplySpecification(Expression<Func<T, bool>> criteria)
        {
            return _dbContext.Set<T>().AsQueryable().Where(criteria);
        }
    }
}
