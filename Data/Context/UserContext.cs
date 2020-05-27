﻿using Data.Configuration;
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class UserContext : DbContext
    {
        UserContext(DbContextOptions<UserContext> options) 
            : base(options)
        { 
        }
        public DbSet<ProfileEntity> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        { 
            modelBuilder.ApplyConfiguration(new ProfileConfiguration()); 
            base.OnModelCreating(modelBuilder); 
        }
    }
}