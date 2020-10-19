using BlogSite.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Entities.Concrete
{
    public class Image : IEntity
    {
        public int ImageId { get; set; }
        public string SmallSize { get; set; }
        public string MediumSize { get; set; }
        public string LargeSize { get; set; }
        public int AuthorId { get; set; }
        public Author Authors { get; set; }

    }
}
