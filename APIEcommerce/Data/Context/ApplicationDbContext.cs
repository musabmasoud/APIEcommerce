﻿using APIEcommerce.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace APIEcommerce.Data.Context
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, UserName = "admin", Password = "admin" });
        }
    }
   
}
