using BlogSite.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Entities.Concrete
{
    public class User : IEntity
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool Gender { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public DateTime BirthDate { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsAuthor { get; set; }


    }
}
