using OgProject.OuzDevBlog.BusinessLayer.Abstract;
using OgProject.OuzDevBlog.DataAccessLayer.Abstarct;
using OgProject.OuzDevBlog.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OgProject.OuzDevBlog.BusinessLayer.Concrate
{
    public class GenericManager<TEntity> : IGenericService<TEntity> where TEntity : class, ITable, new()
    {
        IGenericDal<TEntity> _genericDal;
        public GenericManager(IGenericDal<TEntity> genericDal)
        {
            _genericDal = genericDal;
        }
        public async Task AddAsync(TEntity entity)
        {
            await _genericDal.AddAsync(entity);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await _genericDal.DeleteAsync(entity);
        }

        public async Task<TEntity> FindByIdAsync(int id)
        {
            return await _genericDal.FindByIdAsync(id);

        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _genericDal.GetAllAsync();

        }

       

        public async Task UpdateAsync(TEntity entity)
        {
            await _genericDal.UpdateAsync(entity);
        }
    }
}
