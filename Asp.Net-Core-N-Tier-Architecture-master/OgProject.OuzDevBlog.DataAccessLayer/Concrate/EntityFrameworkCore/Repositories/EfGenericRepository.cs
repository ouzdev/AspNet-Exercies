using Microsoft.EntityFrameworkCore;
using OgProject.OuzDevBlog.DataAccessLayer.Abstarct;
using OgProject.OuzDevBlog.DataAccessLayer.Concrate.EntityFrameworkCore.Context;
using OgProject.OuzDevBlog.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OgProject.OuzDevBlog.DataAccessLayer.Concrate.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<TEntity> : IGenericDal<TEntity> where TEntity : class, ITable, new()
    {
        public async Task AddAsync(TEntity entity)
        {
            using var context = new OuzDevBlogContext();
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }
        public async Task<TEntity> FindByIdAsync(int id)
        {
            using var context = new OuzDevBlogContext();
            return await context.FindAsync<TEntity>(id);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            using var context = new OuzDevBlogContext();
            return await context.Set<TEntity>().ToListAsync();

        }
        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new OuzDevBlogContext();
            return await context.Set<TEntity>().Where(filter).ToListAsync();
        }
        public async Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, bool>> filter,Expression<Func<TEntity,TKey>> keySelector)
        {
            using var context = new OuzDevBlogContext();
            return await context.Set<TEntity>().Where(filter).OrderByDescending(keySelector).ToListAsync();
        }
        public async Task<List<TEntity>> GetAllAsync<TKey>( Expression<Func<TEntity, TKey>> keySelector)
        {
            using var context = new OuzDevBlogContext();
            return await context.Set<TEntity>().OrderByDescending(keySelector).ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new OuzDevBlogContext();
            return await context.Set<TEntity>().FirstOrDefaultAsync(filter);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            using var context = new OuzDevBlogContext();
            context.Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(TEntity entity)
        {
            using var context = new OuzDevBlogContext();
            context.Remove(entity);
            await context.SaveChangesAsync();

        }

       
    }
}
