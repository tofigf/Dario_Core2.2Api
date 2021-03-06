﻿// <auto-generated />
using System;
using Direo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Direo.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190321165707_Listing_Category_Photo_Location_ReviewListing_SideBarForm_Subscriber")]
    partial class Listing_Category_Photo_Location_ReviewListing_SideBarForm_Subscriber
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Direo.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Icon")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Direo.Models.Listing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(50);

                    b.Property<int>("CategoryId");

                    b.Property<string>("Email");

                    b.Property<string>("Facebook")
                        .HasMaxLength(50);

                    b.Property<string>("Google")
                        .HasMaxLength(50);

                    b.Property<bool?>("IsSevenTwentyFour");

                    b.Property<string>("Latitude")
                        .HasMaxLength(100);

                    b.Property<string>("Linkedin")
                        .HasMaxLength(50);

                    b.Property<int>("LocationId");

                    b.Property<string>("LongDescription")
                        .HasColumnType("text");

                    b.Property<string>("Longitude")
                        .HasMaxLength(100);

                    b.Property<string>("Phone")
                        .HasMaxLength(50);

                    b.Property<DateTime>("PostDate");

                    b.Property<decimal?>("Price")
                        .HasColumnType("money");

                    b.Property<decimal?>("Rating");

                    b.Property<string>("ShortDescription")
                        .HasMaxLength(200);

                    b.Property<bool>("Status");

                    b.Property<string>("Tagline")
                        .HasMaxLength(100);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("Twitter")
                        .HasMaxLength(50);

                    b.Property<int>("UserId");

                    b.Property<string>("VideoUrl")
                        .HasMaxLength(50);

                    b.Property<int?>("ViewsCount");

                    b.Property<string>("Website")
                        .HasMaxLength(50);

                    b.Property<string>("Youtube")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("LocationId");

                    b.HasIndex("UserId");

                    b.ToTable("Listings");
                });

            modelBuilder.Entity("Direo.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Direo.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAdded");

                    b.Property<bool>("IsMain");

                    b.Property<int>("ListingId");

                    b.Property<string>("PhotoUrl");

                    b.HasKey("Id");

                    b.HasIndex("ListingId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("Direo.Models.ReviewsListing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ListingId");

                    b.Property<string>("Message");

                    b.Property<string>("PhotoUrl");

                    b.Property<byte>("Rating")
                        .HasColumnType("tinyint");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ListingId");

                    b.HasIndex("UserId");

                    b.ToTable("ReviewsListings");
                });

            modelBuilder.Entity("Direo.Models.SidebarForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("MessageText")
                        .IsRequired();

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("SidebarForms");
                });

            modelBuilder.Entity("Direo.Models.Subscriber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Subscribers");
                });

            modelBuilder.Entity("Direo.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(150);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Desc")
                        .HasMaxLength(500);

                    b.Property<string>("Email")
                        .HasMaxLength(50);

                    b.Property<string>("Facebook")
                        .HasMaxLength(50);

                    b.Property<string>("FirstName")
                        .HasMaxLength(50);

                    b.Property<string>("Gender")
                        .HasMaxLength(20);

                    b.Property<string>("Google")
                        .HasMaxLength(50);

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(150);

                    b.Property<string>("LastName")
                        .HasMaxLength(50);

                    b.Property<string>("Linkedin")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<bool>("Status");

                    b.Property<string>("Twitter")
                        .HasMaxLength(50);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Website")
                        .HasMaxLength(50);

                    b.Property<string>("Youtube")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Direo.Models.Listing", b =>
                {
                    b.HasOne("Direo.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Direo.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Direo.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Direo.Models.Photo", b =>
                {
                    b.HasOne("Direo.Models.Listing", "Listing")
                        .WithMany("Photos")
                        .HasForeignKey("ListingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Direo.Models.ReviewsListing", b =>
                {
                    b.HasOne("Direo.Models.Listing", "Listing")
                        .WithMany("ReviewsListings")
                        .HasForeignKey("ListingId");

                    b.HasOne("Direo.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
