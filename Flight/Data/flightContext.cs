using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Flight.Models;

namespace Flight.Data
{
    public partial class flightContext : DbContext
    {
        public flightContext()
        {
        }

        public flightContext(DbContextOptions<flightContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Flightss> Flightsses { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Routess> Routesses { get; set; } = null!;
        public virtual DbSet<Schedule> Schedules { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-JD70K36;Initial Catalog=flight;Integrated Security=True; Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite; MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("class");

                entity.Property(e => e.ClassId).HasColumnName("class_id");

                entity.Property(e => e.ClassName)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("class_name");

                entity.Property(e => e.Price)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("price");
            });

            modelBuilder.Entity<Flightss>(entity =>
            {
                entity.HasKey(e => e.FId)
                    .HasName("PK__flightss__2911CBED70017765");

                entity.ToTable("flightss");

                entity.Property(e => e.FId).HasColumnName("f_id");

                entity.Property(e => e.FName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("f_name");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.HasIndex(e => e.RoleName, "UQ__role__783254B184C68A2D")
                    .IsUnique();

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("role_name");
            });

            modelBuilder.Entity<Routess>(entity =>
            {
                entity.HasKey(e => e.RId)
                    .HasName("PK__routess__DE142AC187E1006A");

                entity.ToTable("routess");

                entity.Property(e => e.RId).HasColumnName("R_id");

                entity.Property(e => e.RName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("R_name");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.HasKey(e => e.SId)
                    .HasName("PK__schedule__2F3684F4FC26A5E0");

                entity.ToTable("schedule");

                entity.Property(e => e.SId).HasColumnName("s_id");

                entity.Property(e => e.FlightId).HasColumnName("flight_id");

                entity.Property(e => e.RoutessId).HasColumnName("Routess_id");

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.FlightId)
                    .HasConstraintName("FK__schedule__flight__60A75C0F");

                entity.HasOne(d => d.Routess)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.RoutessId)
                    .HasConstraintName("FK__schedule__Routes__619B8048");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UsersId)
                    .HasName("PK__users__EAA7D14B271501CC");

                entity.ToTable("users");

                entity.HasIndex(e => e.UsersEmail, "UQ__users__D156B4FE4DD24033")
                    .IsUnique();

                entity.Property(e => e.UsersId).HasColumnName("users_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.UsersEmail)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("users_email");

                entity.Property(e => e.UsersName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("users_name");

                entity.Property(e => e.UsersPassword)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("users_password");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__users__role_id__3B75D760");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
