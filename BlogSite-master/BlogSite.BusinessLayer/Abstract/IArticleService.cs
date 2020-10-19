using BlogSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.BusinessLayer.Abstract
{
   public interface IArticleService
    {
        List<Article> GettAll();
    }
}
