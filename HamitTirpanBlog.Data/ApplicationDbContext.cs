using System;
using HamitTirpanBlog.Data.Builders;
using HamitTirpanBlog.Model.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HamitTirpanBlog.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Page> Pages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var postBuilder = new PostBuilder(builder.Entity<Post>());
            var pageBuilder = new PageBuilder(builder.Entity<Page>());
            var categoryBuilder = new CategoryBuilder(builder.Entity<Category>());
            var feedbackBuilder = new FeedbackBuilder(builder.Entity<Feedback>());
            var applicationUserBuilder = new ApplicationUserBuilder(builder.Entity<ApplicationUser>());
        }
    }
}
