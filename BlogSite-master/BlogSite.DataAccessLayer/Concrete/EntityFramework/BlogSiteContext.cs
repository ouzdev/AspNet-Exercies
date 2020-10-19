using BlogSite.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.DataAccessLayer.Concrete.EntityFramework
{
    //Hata olursa buradan kontrol et.
    public class BlogSiteContext : DbContext
    {
      

        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<SiteSetting> SiteSettings { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }


    }
    public class InitializeDatabase:CreateDatabaseIfNotExists<BlogSiteContext>
    {
        protected override void Seed(BlogSiteContext context)
        {
            
        }
    }
}
