using System;
using HamitTirpanBlog.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HamitTirpanBlog.Data.Builders
{
    public class ApplicationUserBuilder
    {
        public ApplicationUserBuilder(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(100);
        }
    }
}
