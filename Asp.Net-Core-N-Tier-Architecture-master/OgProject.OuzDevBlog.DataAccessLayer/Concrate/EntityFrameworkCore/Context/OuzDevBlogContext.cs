using Microsoft.EntityFrameworkCore;
using OgProject.OuzDevBlog.DataAccessLayer.Concrate.EntityFrameworkCore.Mapping;
using OgProject.OuzDevBlog.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace OgProject.OuzDevBlog.DataAccessLayer.Concrate.EntityFrameworkCore.Context
{
    public class OuzDevBlogContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=ANDROID-56ADS45\SQLEXPRESS; database=OG.OuzDevBlogDB; integrated security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserMap());
            modelBuilder.ApplyConfiguration(new ArticleMap());
            modelBuilder.ApplyConfiguration(new CategoryArticleMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new CommentMap());

        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryArticle> CategoryArticles { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
