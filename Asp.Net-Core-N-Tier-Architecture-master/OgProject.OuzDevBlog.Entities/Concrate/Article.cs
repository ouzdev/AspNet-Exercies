using OgProject.OuzDevBlog.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace OgProject.OuzDevBlog.Entities.Concrate
{
    public class Article : ITable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public DateTime ReleaseTime { get; set; } = DateTime.Now;

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }


        public List<CategoryArticle> CategoryArticles { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
