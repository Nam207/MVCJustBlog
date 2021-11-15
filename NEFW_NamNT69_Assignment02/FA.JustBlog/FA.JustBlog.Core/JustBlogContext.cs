using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Models.EntityBase;
using FA.JustBlog.Core.Models.Enums;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace FA.JustBlog.Core
{
    public class JustBlogContext : IdentityDbContext<AppUser>
    {
        public JustBlogContext() : base("name = connectionString")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTagMap> PostTagMaps { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public static JustBlogContext Create()
        {
            return new JustBlogContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PostTagMap>().HasKey(ptm => new { ptm.PostId, ptm.TagId });
        }

        public override int SaveChanges()
        {
            BeforSaveChanges();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync()
        {
            BeforSaveChanges();
            return base.SaveChangesAsync();
        }

        private void BeforSaveChanges()
        {
            var entities = ChangeTracker.Entries();

            foreach (var entity in entities)
            {
                if (entity.Entity is IBaseEntity baseEntity)
                {
                    switch (entity.State)
                    {
                        case EntityState.Added:
                            baseEntity.Status = Status.Active;
                            break;

                        case EntityState.Modified:
                            baseEntity.Status = Status.InActive;
                            break;
                    }
                }
            }
        }
    }
}