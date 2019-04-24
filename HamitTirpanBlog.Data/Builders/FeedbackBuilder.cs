using System;
using HamitTirpanBlog.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HamitTirpanBlog.Data.Builders
{
    public class FeedbackBuilder
    {
        public FeedbackBuilder(EntityTypeBuilder<Feedback> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Subject).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Message).IsRequired();
            builder.Property(e => e.Email).IsRequired().HasMaxLength(200);
        }
    }
}
