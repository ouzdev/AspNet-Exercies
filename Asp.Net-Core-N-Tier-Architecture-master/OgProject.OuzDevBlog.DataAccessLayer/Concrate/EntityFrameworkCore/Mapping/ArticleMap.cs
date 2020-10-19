using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OgProject.OuzDevBlog.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace OgProject.OuzDevBlog.DataAccessLayer.Concrate.EntityFrameworkCore.Mapping
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.Title).HasMaxLength(100);
            builder.Property(I => I.ShortDescription).HasMaxLength(300);
            builder.Property(I => I.Description).HasColumnType("ntext");
            builder.Property(I => I.ImagePath).HasMaxLength(300);

            builder.HasMany(I => I.Comments).WithOne(I => I.Article).HasForeignKey(I => I.ArticleId);
            builder.HasMany(I => I.CategoryArticles).WithOne(I => I.Article).HasForeignKey(I => I.ArticleId);

        }
    }
}
