using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using CodeQuery.Models;

namespace CodeQuery.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20160412000158_IncludeOneToManyForUsersAndPosts")]
    partial class IncludeOneToManyForUsersAndPosts
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CodeQuery.Models.Answer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<DateTime>("CreationDate");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<int?>("PostID");

                    b.Property<string>("TimeAgo");

                    b.Property<int>("Votes");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("CodeQuery.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("AboutMe");

                    b.Property<int>("AccessFailedCount");

                    b.Property<DateTime>("Birthday");

                    b.Property<string>("Company");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("DisplayName");

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("GitHub");

                    b.Property<string>("HobbyCode");

                    b.Property<bool>("IsActive");

                    b.Property<string>("LastName");

                    b.Property<string>("Location");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("Position");

                    b.Property<string>("SchoolDegree");

                    b.Property<string>("SchoolName");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("Twitter");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("Website");

                    b.Property<string>("WhereDoYouCode");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasAnnotation("Relational:Name", "EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .HasAnnotation("Relational:Name", "UserNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetUsers");
                });

            modelBuilder.Entity("CodeQuery.Models.Job", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyName");

                    b.Property<string>("Location");

                    b.Property<string>("Title");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("CodeQuery.Models.JobLabel", b =>
                {
                    b.Property<int>("JobID");

                    b.Property<int>("LabelID");

                    b.HasKey("JobID", "LabelID");
                });

            modelBuilder.Entity("CodeQuery.Models.Label", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Text");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("CodeQuery.Models.Post", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("Body");

                    b.Property<DateTime>("CreationDate");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<int>("ReplyCount");

                    b.Property<string>("Title");

                    b.Property<int>("Views");

                    b.Property<int>("Votes");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("CodeQuery.Models.PostLabel", b =>
                {
                    b.Property<int>("PostID");

                    b.Property<int>("LabelID");

                    b.HasKey("PostID", "LabelID");
                });

            modelBuilder.Entity("CodeQuery.Models.Reply", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AnswerID");

                    b.Property<DateTime>("CreationDate");

                    b.Property<string>("Message");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<int?>("PostID");

                    b.HasKey("ID");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasAnnotation("Relational:Name", "RoleNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasAnnotation("Relational:TableName", "AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasAnnotation("Relational:TableName", "AspNetUserRoles");
                });

            modelBuilder.Entity("CodeQuery.Models.Answer", b =>
                {
                    b.HasOne("CodeQuery.Models.Post")
                        .WithMany()
                        .HasForeignKey("PostID");
                });

            modelBuilder.Entity("CodeQuery.Models.JobLabel", b =>
                {
                    b.HasOne("CodeQuery.Models.Job")
                        .WithMany()
                        .HasForeignKey("JobID");

                    b.HasOne("CodeQuery.Models.Label")
                        .WithMany()
                        .HasForeignKey("LabelID");
                });

            modelBuilder.Entity("CodeQuery.Models.Post", b =>
                {
                    b.HasOne("CodeQuery.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("CodeQuery.Models.PostLabel", b =>
                {
                    b.HasOne("CodeQuery.Models.Label")
                        .WithMany()
                        .HasForeignKey("LabelID");

                    b.HasOne("CodeQuery.Models.Post")
                        .WithMany()
                        .HasForeignKey("PostID");
                });

            modelBuilder.Entity("CodeQuery.Models.Reply", b =>
                {
                    b.HasOne("CodeQuery.Models.Answer")
                        .WithMany()
                        .HasForeignKey("AnswerID");

                    b.HasOne("CodeQuery.Models.Post")
                        .WithMany()
                        .HasForeignKey("PostID");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CodeQuery.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CodeQuery.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("CodeQuery.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
        }
    }
}
