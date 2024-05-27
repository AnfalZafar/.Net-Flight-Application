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

        public virtual DbSet<About> Abouts { get; set; } = null!;
        public virtual DbSet<Choose> Chooses { get; set; } = null!;
        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<FlightDetail> FlightDetails { get; set; } = null!;
        public virtual DbSet<Flightss> Flightsses { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Routess> Routesses { get; set; } = null!;
        public virtual DbSet<Schedule> Schedules { get; set; } = null!;
        public virtual DbSet<SpecialSet> SpecialSets { get; set; } = null!;
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
            modelBuilder.Entity<About>(entity =>
            {
                entity.ToTable("about");

                entity.Property(e => e.AboutId).HasColumnName("about_id");

                entity.Property(e => e.AboutDescription)
                    .IsUnicode(false)
                    .HasColumnName("about_description");

                entity.Property(e => e.AboutImg)
                    .IsUnicode(false)
                    .HasColumnName("about_img");

                entity.Property(e => e.AboutName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("about_name");

                entity.Property(e => e.AboutTitle)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("about_title");
            });

            modelBuilder.Entity<Choose>(entity =>
            {
                entity.HasKey(e => e.CId)
                    .HasName("PK__chooses__213EE774CA061F8C");

                entity.ToTable("chooses");

                entity.Property(e => e.CId).HasColumnName("c_id");

                entity.Property(e => e.CDescription)
                    .IsUnicode(false)
                    .HasColumnName("c_description");

                entity.Property(e => e.CName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("c_name");
            });

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

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.HasKey(e => e.FId)
                    .HasName("PK__feedback__2911CBEDC128958F");

                entity.ToTable("feedback");

                entity.Property(e => e.FId).HasColumnName("f_id");

                entity.Property(e => e.FAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("f_address");

                entity.Property(e => e.FEmail)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("f_email");

                entity.Property(e => e.FFeedback)
                    .IsUnicode(false)
                    .HasColumnName("f_feedback");

                entity.Property(e => e.FName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("f_name");

                entity.Property(e => e.FPhone)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("f_phone");
            });

            modelBuilder.Entity<FlightDetail>(entity =>
            {
                entity.HasKey(e => e.FlightId)
                    .HasName("PK__flight_d__E37057657895500E");

                entity.ToTable("flight_detail");

                entity.Property(e => e.FlightId).HasColumnName("flight_id");

                entity.Property(e => e.FlightDescription)
                    .IsUnicode(false)
                    .HasColumnName("flight_description");

                entity.Property(e => e.FlightDetailName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("flight_detail_name");

                entity.Property(e => e.SheduleId).HasColumnName("shedule_id");

                entity.Property(e => e.SpecialId).HasColumnName("special_id");

                entity.HasOne(d => d.Shedule)
                    .WithMany(p => p.FlightDetails)
                    .HasForeignKey(d => d.SheduleId)
                    .HasConstraintName("FK__flight_de__shedu__45BE5BA9");

                entity.HasOne(d => d.Special)
                    .WithMany(p => p.FlightDetails)
                    .HasForeignKey(d => d.SpecialId)
                    .HasConstraintName("FK__flight_de__speci__46B27FE2");
            });

            modelBuilder.Entity<Flightss>(entity =>
            {
                entity.HasKey(e => e.FId)
                    .HasName("PK__flightss__2911CBEDC6C623F0");

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
                    .HasName("PK__routess__DE142AC16C1E50AD");

                entity.ToTable("routess");

                entity.Property(e => e.RId).HasColumnName("R_id");

                entity.Property(e => e.RFrom)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("R_from");

                entity.Property(e => e.RTo)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("R_to");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.HasKey(e => e.SheduleId)
                    .HasName("PK__schedule__4EEE243DA0449678");

                entity.ToTable("schedule");

                entity.Property(e => e.SheduleId).HasColumnName("shedule_id");

                entity.Property(e => e.Arraval)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Departual)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FlightId).HasColumnName("flight_id");

                entity.Property(e => e.Price)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("price");

                entity.Property(e => e.RoutessId).HasColumnName("Routess_id");

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.FlightId)
                    .HasConstraintName("FK__schedule__flight__3864608B");

                entity.HasOne(d => d.Routess)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.RoutessId)
                    .HasConstraintName("FK__schedule__Routes__395884C4");
            });

            modelBuilder.Entity<SpecialSet>(entity =>
            {
                entity.HasKey(e => e.SpecialId)
                    .HasName("PK__special___D325960609AEF8F1");

                entity.ToTable("special_sets");

                entity.Property(e => e.SpecialId).HasColumnName("special_id");

                entity.Property(e => e.FlightId).HasColumnName("flight_id");

                entity.Property(e => e.RoutessId).HasColumnName("Routess_id");

                entity.Property(e => e.SArraval)
                    .HasColumnType("datetime")
                    .HasColumnName("s_Arraval")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SDepartual)
                    .HasColumnType("datetime")
                    .HasColumnName("s_Departual")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SPrice)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("s_price");

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.SpecialSets)
                    .HasForeignKey(d => d.FlightId)
                    .HasConstraintName("FK__special_s__fligh__3E1D39E1");

                entity.HasOne(d => d.Routess)
                    .WithMany(p => p.SpecialSets)
                    .HasForeignKey(d => d.RoutessId)
                    .HasConstraintName("FK__special_s__Route__3F115E1A");
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
