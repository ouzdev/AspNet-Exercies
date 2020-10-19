using OgProject.OuzDevBlog.Entities.Abstract;
using System.Collections.Generic;

namespace OgProject.OuzDevBlog.Entities.Concrate
{
    public class AppUser : ITable
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public List<Article> Articles { get; set; }


    }
}
