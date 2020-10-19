using BlogSite.DataAccessLayer.Abstract;
using BlogSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.DataAccessLayer.Concrete.EntityFramework
{
    public class EfArticleDal:EntittFrameworkRepositoryBase<Article,BlogSiteContext>,IArticleDal
    {

    }
}
