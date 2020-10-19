using OgProject.OuzDevBlog.BusinessLayer.Abstract;
using OgProject.OuzDevBlog.DataAccessLayer.Abstarct;
using OgProject.OuzDevBlog.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OgProject.OuzDevBlog.BusinessLayer.Concrate
{
    public class ArticleManager:GenericManager<Article>,IArticleService
    {
        private readonly IGenericDal<Article> _genericDal;
        public ArticleManager(IGenericDal<Article> genericDal):base(genericDal)
        {
            _genericDal = genericDal;   
        }

        public async Task<List<Article>> GetAllSortedByPostedTimeAsync()
        {
          return await  _genericDal.GetAllAsync(x => x.ReleaseTime);

        }
    }
}
