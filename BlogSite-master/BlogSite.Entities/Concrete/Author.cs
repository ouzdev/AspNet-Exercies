using BlogSite.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Entities.Concrete
{
   public class Author:IEntity
    {
        public int AuthorId { get; set; }
        public string Description { get; set; }


        public virtual List<Author> Authors { get; set; }
    }
}
