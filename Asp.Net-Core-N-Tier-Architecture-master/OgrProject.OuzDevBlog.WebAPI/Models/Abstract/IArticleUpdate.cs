using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OgrProject.OuzDevBlog.WebAPI.Models.Abstract
{
    public interface IArticleUpdate
    {
        int Id { get; set; }
        string Title { get; set; }
        string ShortDescription { get; set; }
        string Description { get; set; }
        string ImagePath { get; set; }
        int AppUserId { get; set; }
        IFormFile Image { get; set; }
    }
}
