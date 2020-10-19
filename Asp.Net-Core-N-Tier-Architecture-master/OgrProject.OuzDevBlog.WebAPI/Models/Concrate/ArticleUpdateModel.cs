using Microsoft.AspNetCore.Http;
using OgrProject.OuzDevBlog.WebAPI.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OgrProject.OuzDevBlog.WebAPI.Models
{
    public class ArticleUpdateModel:IArticleUpdate
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int AppUserId { get; set; }
        public IFormFile Image { get; set; }
    }
}
