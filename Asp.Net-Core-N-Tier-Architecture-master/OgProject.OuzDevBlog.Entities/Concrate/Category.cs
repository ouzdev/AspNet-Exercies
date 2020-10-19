using OgProject.OuzDevBlog.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace OgProject.OuzDevBlog.Entities.Concrate
{
    public class Category:ITable
    {

        //Sınırsız kategori yapılacak ileride....
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public DateTime UpdateTime { get; set; }

       public List<CategoryArticle> CategoryBlogs { get; set; }

    }
}
