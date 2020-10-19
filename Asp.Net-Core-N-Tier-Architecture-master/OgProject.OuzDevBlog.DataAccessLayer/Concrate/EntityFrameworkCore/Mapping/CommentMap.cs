using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OgProject.OuzDevBlog.Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace OgProject.OuzDevBlog.DataAccessLayer.Concrate.EntityFrameworkCore.Mapping
{
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.CommentUserName).HasMaxLength(100).IsRequired();
            builder.Property(I => I.CommentUserEmail).HasMaxLength(100).IsRequired();
            builder.Property(I => I.Description).HasMaxLength(400).IsRequired();

            builder.HasOne(I => I.ParentComment).WithMany(I => I.SubComments).HasForeignKey(I => I.ParentCommentId);

        }
    }
}
