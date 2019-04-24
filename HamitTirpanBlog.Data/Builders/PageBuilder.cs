using System;
using HamitTirpanBlog.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HamitTirpanBlog.Data.Builders
{
    public class PageBuilder
    {
        public PageBuilder(EntityTypeBuilder<Page> builder)
        {
            builder.Property(e => e.Title).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Description).IsRequired().HasMaxLength(3000);
        }
    }
}
