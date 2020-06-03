using Data.Configuration;
using Domain.Model;
using Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) 
            : base(options)
        { 
        }
        public DbSet<ProfileEntity> Users { get; set; }
        public DbSet<PostEntity> Posts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        { 
            modelBuilder.ApplyConfiguration(new ProfileConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            base.OnModelCreating(modelBuilder); 
        }
    }
}
