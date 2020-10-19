using OgProject.OuzDevBlog.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace OgProject.OuzDevBlog.Entities.Concrate
{
    public class Comment:ITable
    {
        public int Id { get; set; }
        public string CommentUserName { get; set; }
        public string CommentUserEmail { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseTime { get; set; } = DateTime.Now;

        public int? ParentCommentId { get; set; }
        public Comment ParentComment { get; set; }

        public List<Comment> SubComments { get; set; }

        public int ArticleId { get; set; }
        public Article Article { get; set; }

    }
}
