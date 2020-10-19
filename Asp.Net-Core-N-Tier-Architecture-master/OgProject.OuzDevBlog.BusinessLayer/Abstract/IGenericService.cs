using OgProject.OuzDevBlog.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OgProject.OuzDevBlog.BusinessLayer.Abstract
{
    public interface IGenericService<TEntity> where TEntity:class,ITable,new()
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> FindByIdAsync(int id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
