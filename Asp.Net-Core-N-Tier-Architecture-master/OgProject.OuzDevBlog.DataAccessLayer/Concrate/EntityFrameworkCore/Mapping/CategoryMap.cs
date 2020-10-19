using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OgProject.OuzDevBlog.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace OgProject.OuzDevBlog.DataAccessLayer.Concrate.EntityFrameworkCore.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.Name).HasMaxLength(100).IsRequired();

            builder.HasMany(I => I.CategoryBlogs).WithOne(I => I.Category).HasForeignKey(I => I.CategoryId);
        }
    }
}
