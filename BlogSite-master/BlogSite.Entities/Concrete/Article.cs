using BlogSite.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Entities.Concrete
{
    public class Article : IEntity
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public DateTime DateOfUpload { get; set; }
        //public DateTime DateOfUpdate { get; set; }
        public string Keywords { get; set; }
        public int Views { get; set; }
        public int LikeCount { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsDraft { get; set; }



        public int CategoryId { get; set; }
        public int AuthorId { get; set; }


        public virtual List<Comment> Comments { get; set; }
        public virtual List<Image> Images { get; set; }
        public virtual List<Tag> Tags { get; set; }
        public virtual Author Authors { get; set; }
        public virtual Category Category { get; set; }
        

    }
}
