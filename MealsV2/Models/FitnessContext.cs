using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MealsV2.Models
{
    public partial class FitnessContext : DbContext
    {
        public FitnessContext()
        {
        }

        public FitnessContext(DbContextOptions<FitnessContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FoodCat> FoodCats { get; set; } = null!;
        public virtual DbSet<MainCat> MainCats { get; set; } = null!;
        public virtual DbSet<Meal> Meals { get; set; } = null!;
        public virtual DbSet<UserDatum> UserData { get; set; } = null!;
        public virtual DbSet<UserLogin> UserLogins { get; set; } = null!;
        public virtual DbSet<UserMeal> UserMeals { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;initial catalog=MealsV2;integrated security=True;App=EntityFramework");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FoodCat>(entity =>
            {
                entity.ToTable("FoodCat");

                entity.Property(e => e.FoodName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MainCat>(entity =>
            {
                entity.ToTable("MainCat");

                entity.Property(e => e.CatName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Meal>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.FoodCat)
                    .WithMany(p => p.Meals)
                    .HasForeignKey(d => d.FoodCatId)
                    .HasConstraintName("FK__Meals__FoodCatId__2C3393D0");
            });

            modelBuilder.Entity<UserDatum>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserData__1788CC4CDC5CFE4A");

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nationality)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.HasKey(e => e.Email);

                entity.ToTable("UserLogin");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);


                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserLogin__UserI__25869641");
            });

            modelBuilder.Entity<UserMeal>(entity =>
            {
                entity.HasKey(e => new { e.UserMealDate, e.UserId, e.MealId })
                    .HasName("PK__UserMeal__3B16655B336CCC12");

                entity.Property(e => e.UserMealDate).HasColumnType("datetime");

                entity.HasOne(d => d.MainCat)
                    .WithMany(p => p.UserMeals)
                    .HasForeignKey(d => d.MainCatId)
                    .HasConstraintName("FK__UserMeals__MainC__30F848ED");

                entity.HasOne(d => d.Meal)
                    .WithMany(p => p.UserMeals)
                    .HasForeignKey(d => d.MealId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserMeals__MealI__300424B4");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserMeals)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserMeals__UserI__2F10007B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
