using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MySocialNetwork2021.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MySocialNetwork2021.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<PhotoAlbum> PhotoAlbums { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Ban> Bans { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();

        }
    }
}
