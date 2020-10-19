using BlogSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.DataAccessLayer.Abstract
{
   public interface IArticleDal:IEntityRepository<Article>
    {
    }
}
