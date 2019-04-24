using System;
using HamitTirpanBlog.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HamitTirpanBlog.Data.Builders
{
    public class CategoryBuilder
    {
        public CategoryBuilder(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
        }
    }
}
