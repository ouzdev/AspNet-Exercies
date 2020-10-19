using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OgProject.OuzDevBlog.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace OgProject.OuzDevBlog.DataAccessLayer.Concrate.EntityFrameworkCore.Mapping
{
    public class CategoryArticleMap : IEntityTypeConfiguration<CategoryArticle>
    {
        public void Configure(EntityTypeBuilder<CategoryArticle> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.HasIndex(I => new { I.ArticleId, I.CategoryId }).IsUnique();
        }
    }
}
