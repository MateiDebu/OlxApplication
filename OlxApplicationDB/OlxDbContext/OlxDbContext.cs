﻿using Microsoft.EntityFrameworkCore;
using OlxApplicationDB.Models;

namespace OlxApplicationDB.OlxDbContext
{
    public class OlxDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.;Database=OlxApp; Integrated Security=true;");
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Ad> Ads { get; set;}
    }
}
