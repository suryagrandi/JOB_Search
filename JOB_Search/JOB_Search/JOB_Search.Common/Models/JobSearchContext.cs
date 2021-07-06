using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JOB_Search.Common.Models
{
    public partial class JobSearchContext : DbContext
    {
        public JobSearchContext()
        {
        }

        public JobSearchContext(DbContextOptions<JobSearchContext> options)
            : base(options)
        {
        }

        public virtual DbSet<JobProfiles> JobProfiles { get; set; }
        public virtual DbSet<Languagedetails> Languagedetails { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               optionsBuilder.UseMySQL("Server=127.0.0.1;port=3306;Database=job_search;Uid=root;Pwd=Surya786@");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobProfiles>(entity =>
            {
                entity.HasKey(e => e.JobId)
                    .HasName("PRIMARY");

                entity.ToTable("job_profiles");

                entity.HasComment("					");

                entity.Property(e => e.JobId).HasColumnName("job_id");

                entity.Property(e => e.Availability)
                    .HasColumnName("availability")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Experience).HasColumnName("experience");

                entity.Property(e => e.JobDescription)
                    .HasColumnName("job_description")
                    .HasMaxLength(145)
                    .IsUnicode(false);

                entity.Property(e => e.JobTitle)
                    .HasColumnName("job_title")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.JobType)
                    .HasColumnName("job_type")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.Property(e => e.PayRate).HasColumnName("pay_rate");

                entity.Property(e => e.ReplyRate).HasColumnName("reply_rate");

                entity.Property(e => e.SkillId).HasColumnName("skill_id");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<Languagedetails>(entity =>
            {
                entity.HasKey(e => e.LanguageId)
                    .HasName("PRIMARY");

                entity.ToTable("languagedetails");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.Property(e => e.Language)
                    .HasColumnName("language")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.ToTable("skill");

                entity.Property(e => e.SkillId).HasColumnName("skill_id");

                entity.Property(e => e.SkillName)
                    .HasColumnName("skill_name")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PRIMARY");

                entity.ToTable("users");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.UserName)
                    .HasColumnName("user_name")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
