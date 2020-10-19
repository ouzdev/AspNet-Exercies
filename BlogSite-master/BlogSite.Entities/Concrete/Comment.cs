using BlogSite.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Entities.Concrete
{
    public class Comment : IEntity
    {
        public int CommentId { get; set; }
        public string Comments { get; set; }
        public string IpAdress { get; set; }
        public string NameSurname { get; set; }
        public int LikeCount { get; set; }

        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }
    }
}
