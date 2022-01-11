using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LicentaB.Models
{
    public partial class dbLicentaContext : DbContext
    {
        public dbLicentaContext()
        {
        }

        public dbLicentaContext(DbContextOptions<dbLicentaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseCertificate> CourseCertificates { get; set; }
        public virtual DbSet<CourseCreate> CourseCreates { get; set; }
        public virtual DbSet<CourseReview> CourseReviews { get; set; }
        public virtual DbSet<CourseType> CourseTypes { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<Quizz> Quizzs { get; set; }
        public virtual DbSet<StudentEnrolment> StudentEnrolments { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<WishList> WishLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=dbLicenta;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Romanian_100_CI_AS");

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("First_Name");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Last_Name");

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany()
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("category_name");

                entity.Property(e => e.SubcategoryId).HasColumnName("Subcategory_Id");

                entity.HasOne(d => d.Subcategory)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.SubcategoryId)
                    .HasConstraintName("FK_Category_SubCategory");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

                entity.Property(e => e.CourseDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("course_description");

                entity.Property(e => e.CourseModulesNumber).HasColumnName("course_modulesNumber");

                entity.Property(e => e.CourseName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("course_Name");

                entity.Property(e => e.CoursePrice).HasColumnName("course_price");

                entity.Property(e => e.CourseRating).HasColumnName("course_rating");

                entity.Property(e => e.CourseRequirement)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("course_requirement");

                entity.Property(e => e.CourseTypeId).HasColumnName("Course_TypeId");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.Property(e => e.WhatLearning)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("what_learning");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Course_Category");

                entity.HasOne(d => d.CourseType)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.CourseTypeId)
                    .HasConstraintName("FK_Course_Course_Type");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Course_AspNetUsers");

                entity.HasOne(d => d.UserNavigation)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Course_Course_Create");
            });

            modelBuilder.Entity<CourseCertificate>(entity =>
            {
                entity.ToTable("Course_Certificate");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CertificateDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Certificate_Description");

                entity.Property(e => e.CertificateName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Certificate_Name");

                entity.Property(e => e.CourseId).HasColumnName("Course_Id");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseCertificates)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_Course_Certificate_Course");
            });

            modelBuilder.Entity<CourseCreate>(entity =>
            {
                entity.ToTable("Course_Create");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DataCreation)
                    .HasColumnType("date")
                    .HasColumnName("data_creation");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CourseCreates)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Course_Create_AspNetUsers");
            });

            modelBuilder.Entity<CourseReview>(entity =>
            {
                entity.ToTable("Course_Reviews");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CourseId).HasColumnName("Course_Id");

                entity.Property(e => e.ReviewDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Review_Description");

                entity.Property(e => e.ReviewRating).HasColumnName("Review_Rating");

                entity.Property(e => e.ReviewTitle)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Review_Title");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseReviews)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_Course_Reviews_Course");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CourseReviews)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Course_Reviews_AspNetUsers");
            });

            modelBuilder.Entity<CourseType>(entity =>
            {
                entity.ToTable("Course_Type");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CourseTypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Course_TypeName");
            });

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.ToTable("Lesson");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.LessonLiveStreamDate)
                    .HasColumnType("date")
                    .HasColumnName("lesson_liveStreamDate");

                entity.Property(e => e.LessonName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lesson_Name");

                entity.Property(e => e.LessonPdf)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lesson_pdf");

                entity.Property(e => e.LessonVideoPath)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lesson_videoPath");

                entity.Property(e => e.ModuleId).HasColumnName("Module_Id");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.Lessons)
                    .HasForeignKey(d => d.ModuleId)
                    .HasConstraintName("FK_Lesson_Module");
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.ToTable("Module");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CourseId).HasColumnName("Course_Id");

                entity.Property(e => e.LessonNumber).HasColumnName("lesson_number");

                entity.Property(e => e.ModuleDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("module_description");

                entity.Property(e => e.ModuleName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("module_name");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Modules)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_Module_Course");
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.ToTable("Payment_type");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.PaymentType1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Payment_Type");
            });

            modelBuilder.Entity<Quizz>(entity =>
            {
                entity.ToTable("Quizz");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Answers)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("answers");

                entity.Property(e => e.CorrectAnswer)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("correct_answer");

                entity.Property(e => e.ModuleId).HasColumnName("Module_Id");

                entity.Property(e => e.QuestionName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("question_name");

                entity.Property(e => e.Score).HasColumnName("score");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.Quizzs)
                    .HasForeignKey(d => d.ModuleId)
                    .HasConstraintName("FK_Quizz_Module");
            });

            modelBuilder.Entity<StudentEnrolment>(entity =>
            {
                entity.ToTable("Student_Enrolment");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CourseId).HasColumnName("Course_Id");

                entity.Property(e => e.DateCompletion)
                    .HasColumnType("date")
                    .HasColumnName("Date_Completion");

                entity.Property(e => e.DateEnrolment)
                    .HasColumnType("date")
                    .HasColumnName("Date_Enrolment");

                entity.Property(e => e.PaymentTypeId).HasColumnName("Payment_typeId");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.StudentEnrolments)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_Student_Enrolment_Course");

                entity.HasOne(d => d.PaymentType)
                    .WithMany(p => p.StudentEnrolments)
                    .HasForeignKey(d => d.PaymentTypeId)
                    .HasConstraintName("FK_Student_Enrolment_Payment_type");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.StudentEnrolments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Student_Enrolment_AspNetUsers");
            });

            modelBuilder.Entity<SubCategory>(entity =>
            {
                entity.ToTable("SubCategory");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.SubCategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("subCategory_name");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.ToTable("Test");

                entity.Property(e => e.TestNume).HasColumnName("testNume");
            });

            modelBuilder.Entity<WishList>(entity =>
            {
                entity.ToTable("WishList");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CourseId).HasColumnName("Course_Id");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.WishLists)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_WishList_Course");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.WishLists)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_WishList_AspNetUsers");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
