using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyResume.Models
{
    public partial class CardContext : DbContext
    {
        public CardContext()
        {
        }

        public CardContext(DbContextOptions<CardContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Articles> Articles { get; set; }
        public virtual DbSet<Educations> Educations { get; set; }
        public virtual DbSet<Experiences> Experiences { get; set; }
        public virtual DbSet<Skills> Skills { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(local);Database=Card;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articles>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.About)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Link).HasColumnType("ntext");

                entity.Property(e => e.PicAddress)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(70);
            });

            modelBuilder.Entity<Educations>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Explain1)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Explain2)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(70);
            });

            modelBuilder.Entity<Experiences>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Explain1)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Explain2)
                    .IsRequired()
                    .HasColumnName("explain2")
                    .HasMaxLength(500);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(70);
            });

            modelBuilder.Entity<Skills>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(70);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Family)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(70);

                entity.Property(e => e.PassWord)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(40);
            });
        }
    }
}
