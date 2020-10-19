using OgProject.OuzDevBlog.BusinessLayer.Abstract;
using OgProject.OuzDevBlog.DataAccessLayer.Abstarct;
using OgProject.OuzDevBlog.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OgProject.OuzDevBlog.BusinessLayer.Concrate
{
  public class CategoryManager:GenericManager<Category>,ICategoryService
    {
        private readonly IGenericDal<Category> _genericDal;

        public CategoryManager(IGenericDal<Category> genericDal) : base(genericDal)
        {
            _genericDal = genericDal;
        }

        public async Task<List<Category>> GetAllSertedById()
        {
            return await _genericDal.GetAllAsync(x => x.Id);
        }
    }
}
