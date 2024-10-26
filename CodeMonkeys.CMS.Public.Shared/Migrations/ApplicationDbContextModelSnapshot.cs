﻿// <auto-generated />
using System;
using CodeMonkeys.CMS.Public.Shared.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CodeMonkeys.CMS.Public.Shared.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CodeMonkeys.CMS.Public.Shared.Entities.Content", b =>
                {
                    b.Property<int>("ContentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContentId"));

                    b.Property<Guid?>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrdinalNumber")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WebPageId")
                        .HasColumnType("int");

                    b.HasKey("ContentId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("WebPageId");

                    b.ToTable("Contents");

                    b.HasDiscriminator().HasValue("Content");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("CodeMonkeys.CMS.Public.Shared.Entities.Menu", b =>
                {
                    b.Property<int>("MenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MenuId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SiteId")
                        .HasColumnType("int");

                    b.HasKey("MenuId");

                    b.HasIndex("SiteId");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("CodeMonkeys.CMS.Public.Shared.Entities.MenuItem", b =>
                {
                    b.Property<int>("MenuItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MenuItemId"));

                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<int>("WebPageId")
                        .HasColumnType("int");

                    b.HasKey("MenuItemId");

                    b.HasIndex("MenuId");

                    b.HasIndex("WebPageId");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("CodeMonkeys.CMS.Public.Shared.Entities.PageStats", b =>
                {
                    b.Property<int>("PageStatsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PageStatsId"));

                    b.Property<int>("PageId")
                        .HasColumnType("int");

                    b.Property<string>("PageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PageVisits")
                        .HasColumnType("int");

                    b.Property<int>("SiteId")
                        .HasColumnType("int");

                    b.HasKey("PageStatsId");

                    b.ToTable("PageStats");
                });

            modelBuilder.Entity("CodeMonkeys.CMS.Public.Shared.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("CodeMonkeys.CMS.Public.Shared.Entities.Section", b =>
                {
                    b.Property<int>("SectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SectionId"));

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("WebPageId")
                        .HasColumnType("int");

                    b.HasKey("SectionId");

                    b.HasIndex("WebPageId");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("CodeMonkeys.CMS.Public.Shared.Entities.Site", b =>
                {
                    b.Property<int>("SiteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SiteId"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("LandingPageId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SiteId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("LandingPageId");

                    b.ToTable("Sites");
                });

            modelBuilder.Entity("CodeMonkeys.CMS.Public.Shared.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CodeMonkeys.CMS.Public.Shared.Entities.WebPage", b =>
                {
                    b.Property<int>("WebPageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WebPageId"));

                    b.Property<Guid?>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("SiteId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WebPageId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("SiteId");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("CodeMonkeys.CMS.Public.Shared.Entities.CodeContent", b =>
                {
                    b.HasBaseType("CodeMonkeys.CMS.Public.Shared.Entities.Content");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("CodeContent");
                });

            modelBuilder.Entity("CodeMonkeys.CMS.Public.Shared.Entities.ContentItem", b =>
                {
                    b.HasBaseType("CodeMonkeys.CMS.Public.Shared.Entities.Content");

                    b.Property<string>("FontFamily")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FontSize")
                        .HasColumnType("int");

                    b.Property<bool>("IsBold")
                        .HasColumnType("bit");

                    b.Property<bool>("IsItalic")
                        .HasColumnType("bit");

                    b.Property<bool>("IsLinkEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("LinkDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SectionId")
                        .HasColumnType("int");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TextAlign")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TextColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("SectionId");

                    b.HasDiscriminator().HasValue("ContentItem");
                });

            modelBuilder.Entity("CodeMonkeys.CMS.Public.Shared.Entities.FileContent", b =>
                {
                    b.HasBaseType("CodeMonkeys.CMS.Public.Shared.Entities.Content");

                    b.Property<string>("FileUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("FileContent");
                });

            modelBuilder.Entity("CodeMonkeys.CMS.Public.Shared.Entities.ImageContent", b =>
                {
                    b.HasBaseType("CodeMonkeys.CMS.Public.Shared.Entities.Content");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("ImageContent");
                });

            modelBuilder.Entity("CodeMonkeys.CMS.Public.Shared.Entities.LinkContent", b =>
                {
                    b.HasBaseType("CodeMonkeys.CMS.Public.Shared.Entities.Content");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("LinkDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Contents", t =>
                        {
                            t.Property("LinkDescription")
                                .HasColumnName("LinkContent_LinkDescription");

                            t.Property("LinkUrl")
                                .HasColumnName("LinkContent_LinkUrl");
                        });

                    b.HasDiscriminator().HasValue("LinkContent");
                });

            modelBuilder.Entity("CodeMonkeys.CMS.Public.Shared.Entities.QuoteContent", b =>
                {
                    b.HasBaseType("CodeMonkeys.CMS.Public.Shared.Entities.Content");

                    b.Property<string>("Quote")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuoteAuthor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("QuoteContent");
                });

            modelBuilder.Entity("CodeMonkeys.CMS.Public.Shared.Entities.TextContent", b =>
                {
                    b.HasBaseType("CodeMonkeys.CMS.Public.Shared.Entities.Content");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Contents", t =>
                        {
                            t.Property("Text")
                                .HasColumnName("TextContent_Text");
                        });

                    b.HasDiscriminator().HasValue("TextContent");
                });

            modelBuilder.Entity("CodeMonkeys.CMS.Public.Shared.Entities.VideoContent", b =>
                {
                    b.HasBaseType("CodeMonkeys.CMS.Public.Shared.Entities.Content");

                    b.Property<string>("VideoUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("VideoContent");
                });

            modelBuilder.Entity("CodeMonkeys.CMS.Public.Shared.Entities.Content", b =>
                {
                    b.HasOne("CodeMonkeys.CMS.Public.Shared.Entities.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.HasOne("CodeMonkeys.CMS.Public.Shared.Entities.WebPage", "WebPage")
                        .WithMany("Contents")
                        .HasForeignKey("WebPageId");

                    b.Navigation("Author");

                    b.Navigation("WebPage");
                });

            modelBuilder.Entity("CodeMonkeys.CMS.Public.Shared.Entities.Menu", b =>
                {
                    b.HasOne("CodeMonkeys.CMS.Public.Shared.Entities.Site", "Site")
                        .WithMany("Menus")
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Site");
                });

            modelBuilder.Entity("CodeMonkeys.CMS.Public.Shared.Entities.MenuItem", b =>
                {
                    b.HasOne("CodeMonkeys.CMS.Public.Shared.Entities.Menu", "Menu")
                        .WithMany("Items")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CodeMonkeys.CMS.Public.Shared.Entities.WebPage", "WebPage")
                        .WithMany()
                        .HasForeignKey("WebPageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");

                    b.Navigation("WebPage");
                });

            modelBuilder.Entity("CodeMonkeys.CMS.Public.Shared.Entities.Section", b =>
                {
                    b.HasOne("CodeMonkeys.CMS.Public.Shared.Entities.WebPage", "WebPage")
                        .WithMany("Sections")
                        .HasForeignKey("WebPageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WebPage");
                });

            modelBuilder.Entity("CodeMonkeys.CMS.Public.Shared.Entities.Site", b =>
                {
                    b.HasOne("CodeMonkeys.CMS.Public.Shared.Entities.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");

                    b.HasOne("CodeMonkeys.CMS.Public.Shared.Entities.WebPage", "LandingPage")
                        .WithMany()
                        .HasForeignKey("LandingPageId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Creator");

                    b.Navigation("LandingPage");
                });

            modelBuilder.Entity("CodeMonkeys.CMS.Public.Shared.Entities.WebPage", b =>
                {
                    b.HasOne("CodeMonkeys.CMS.Public.Shared.Entities.User", "Author")
                        .WithMany("Pages")
                        .HasForeignKey("AuthorId");

                    b.HasOne("CodeMonkeys.CMS.Public.Shared.Entities.Site", "Site")
                        .WithMany("Pages")
                        .HasForeignKey("SiteId");

                    b.Navigation("Author");

                    b.Navigation("Site");
                });

            modelBuilder.Entity("CodeMonkeys.CMS.Public.Shared.Entities.ContentItem", b =>
                {
                    b.HasOne("CodeMonkeys.CMS.Public.Shared.Entities.Section", "Section")
                        .WithMany("ContentItems")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Section");
                });

            modelBuilder.Entity("CodeMonkeys.CMS.Public.Shared.Entities.Menu", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("CodeMonkeys.CMS.Public.Shared.Entities.Section", b =>
                {
                    b.Navigation("ContentItems");
                });

            modelBuilder.Entity("CodeMonkeys.CMS.Public.Shared.Entities.Site", b =>
                {
                    b.Navigation("Menus");

                    b.Navigation("Pages");
                });

            modelBuilder.Entity("CodeMonkeys.CMS.Public.Shared.Entities.User", b =>
                {
                    b.Navigation("Pages");
                });

            modelBuilder.Entity("CodeMonkeys.CMS.Public.Shared.Entities.WebPage", b =>
                {
                    b.Navigation("Contents");

                    b.Navigation("Sections");
                });
#pragma warning restore 612, 618
        }
    }
}
