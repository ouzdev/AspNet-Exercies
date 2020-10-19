using OgProject.OuzDevBlog.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OgProject.OuzDevBlog.BusinessLayer.Abstract
{
    public interface IArticleService:IGenericService<Article>
    {
        Task<List<Article>> GetAllSortedByPostedTimeAsync();
    }
}
