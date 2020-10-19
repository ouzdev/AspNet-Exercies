using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OgProject.OuzDevBlog.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace OgProject.OuzDevBlog.DataAccessLayer.Concrate.EntityFrameworkCore.Mapping
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Username).HasMaxLength(100).IsRequired();
            builder.Property(I => I.Password).HasMaxLength(100).IsRequired();
            builder.Property(I => I.Name).HasMaxLength(100);
            builder.Property(I => I.Surname).HasMaxLength(100);
            builder.Property(I => I.Email).HasMaxLength(100);
            

            builder.HasMany(I => I.Articles).WithOne(I => I.AppUser).HasForeignKey(I => I.AppUserId);



        }
    }
}
