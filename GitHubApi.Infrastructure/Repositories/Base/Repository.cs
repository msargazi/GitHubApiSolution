using Microsoft.EntityFrameworkCore;
using GitHubApi.Core.Entities.Base;
using GitHubApi.Core.IRepositories.Base;
using GitHubApi.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GitHubApi.Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        #region Fileds
        protected readonly GitHubApiContext _dbContext;
        #endregion

        #region Const
        public Repository(GitHubApiContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion


        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> perdicate)
        {
            return await _dbContext.Set<T>().Where(perdicate).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> perdicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeString = null, bool disableTraking = true)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (disableTraking) query = query.AsNoTracking();

            if (!string.IsNullOrEmpty(includeString)) query = query.Include(includeString);

            if (perdicate != null) query = query.Where(perdicate);

            if (orderBy != null)
                return await orderBy(query).ToListAsync();
            return await query.ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> perdicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includes = null, bool disableTraking = true)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (disableTraking) query = query.AsNoTracking();

            if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

            if (perdicate != null) query = query.Where(perdicate);

            if (orderBy != null)
                return await orderBy(query).ToListAsync();
            return await query.ToListAsync();
        }
        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;

        }
        public async Task UpdateAsync(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
