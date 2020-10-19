using BlogSite.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Entities.Concrete
{
    public class Tag : IEntity
    {
        public int TagId { get; set; }
        public string Name { get; set; }

        public int ArticleId { get; set; }

        public virtual Article Articles { get; set; }


    }
}
