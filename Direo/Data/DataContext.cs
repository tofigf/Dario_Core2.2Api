using Direo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Direo.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
          public DbSet<User> Users { get; set; }
        public DbSet<CategoryDtos> Categories { get; set; }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<ReviewsListing> ReviewsListings { get; set; }
        public DbSet<SidebarForm> SidebarForms { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ListingTag> ListingTags { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ListingTag>().HasKey(da =>
        //      new { da.ListingId, da.TagId });

        //    modelBuilder.Entity<ListingTag>()
        //        .HasOne(da => da.Listing)
        //        .WithMany(p => p.Tags)
        //        .HasForeignKey(pt => pt.ListingId);

        //    modelBuilder.Entity<ListingTag>()
        //        .HasOne(pt => pt.Tag)
        //        .WithMany(t => t.Listings)
        //        .HasForeignKey(pt => pt.TagId);
        //}

    }
}
