using OgrProject.OuzDevBlog.DTO.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace OgrProject.OuzDevBlog.DTO.DTOs
{
    public class ArticleListDTO:IDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public DateTime ReleaseTime { get; set; } = DateTime.Now;
    }
}
