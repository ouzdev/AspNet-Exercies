using BlogSite.BusinessLayer.Abstract;
using BlogSite.DataAccessLayer.Abstract;
using BlogSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.BusinessLayer.Concrete
{
    public class ArticleManager : IArticleService
    {
        IArticleDal _article;
        public ArticleManager(IArticleDal article)
        {
            _article = article;
        }
        
        public List<Article> GettAll()
        {
            return _article.GetAll();
        }
    }
}
