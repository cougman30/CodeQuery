using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;

namespace CodeQuery.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Reply> Replys { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<PostLabel> PostLabels { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobLabel> JobLabels { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PostLabel>().HasKey(x => new { x.PostID, x.LabelID });
            builder.Entity<JobLabel>().HasKey(x => new { x.JobID, x.LabelID });

            //builder.Entity<Reply>().HasOne(r => r.ID).WithMany(b => b.).OnDelete(DeleteBehavior.Restrict);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
