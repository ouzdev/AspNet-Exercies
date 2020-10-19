using OgProject.OuzDevBlog.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OgProject.OuzDevBlog.BusinessLayer.Abstract
{
   public interface ICategoryService:IGenericService<Category>
    {
        Task<List<Category>> GetAllSertedById();
    }
}
