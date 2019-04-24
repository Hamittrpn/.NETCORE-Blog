using System;
using HamitTirpanBlog.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HamitTirpanBlog.Data.Builders
{
    public class PostBuilder
    {
        public PostBuilder(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Title).IsRequired().HasMaxLength(200);
            builder.HasOne(b => b.Category).WithMany(b => b.Posts).HasForeignKey(b => b.CategoryId);
        }
    }
}
