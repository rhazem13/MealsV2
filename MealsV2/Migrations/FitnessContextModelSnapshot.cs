// <auto-generated />
using System;
using MealsV2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MealsV2.Migrations
{
    [DbContext(typeof(FitnessContext))]
    partial class FitnessContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MealsV2.Models.FoodCat", b =>
                {
                    b.Property<int>("FoodCatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FoodCatId"), 1L, 1);

                    b.Property<string>("FoodName")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.HasKey("FoodCatId");

                    b.ToTable("FoodCat", (string)null);
                });

            modelBuilder.Entity("MealsV2.Models.MainCat", b =>
                {
                    b.Property<int>("MainCatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MainCatId"), 1L, 1);

                    b.Property<string>("CatName")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.HasKey("MainCatId");

                    b.ToTable("MainCat", (string)null);
                });

            modelBuilder.Entity("MealsV2.Models.Meal", b =>
                {
                    b.Property<int>("MealId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MealId"), 1L, 1);

                    b.Property<int?>("Calories")
                        .HasColumnType("int");

                    b.Property<int?>("FoodCatId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsCountable")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.HasKey("MealId");

                    b.HasIndex("FoodCatId");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("MealsV2.Models.UserDatum", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<byte?>("ActivityLevel")
                        .HasColumnType("tinyint");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("char(1)")
                        .IsFixedLength();

                    b.Property<double?>("Height")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Nationality")
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<int?>("RecommendedCalories")
                        .HasColumnType("int");

                    b.Property<double?>("Weight")
                        .HasColumnType("float");

                    b.HasKey("UserId")
                        .HasName("PK__UserData__1788CC4CDC5CFE4A");

                    b.ToTable("UserData");
                });

            modelBuilder.Entity("MealsV2.Models.UserLogin", b =>
                {
                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Email");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogin", (string)null);
                });

            modelBuilder.Entity("MealsV2.Models.UserMeal", b =>
                {
                    b.Property<DateTime>("UserMealDate")
                        .HasColumnType("datetime");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("MealId")
                        .HasColumnType("int");

                    b.Property<int?>("MainCatId")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("UserMealDate", "UserId", "MealId")
                        .HasName("PK__UserMeal__3B16655B336CCC12");

                    b.HasIndex("MainCatId");

                    b.HasIndex("MealId");

                    b.HasIndex("UserId");

                    b.ToTable("UserMeals");
                });

            modelBuilder.Entity("MealsV2.Models.Meal", b =>
                {
                    b.HasOne("MealsV2.Models.FoodCat", "FoodCat")
                        .WithMany("Meals")
                        .HasForeignKey("FoodCatId")
                        .HasConstraintName("FK__Meals__FoodCatId__2C3393D0");

                    b.Navigation("FoodCat");
                });

            modelBuilder.Entity("MealsV2.Models.UserLogin", b =>
                {
                    b.HasOne("MealsV2.Models.UserDatum", "User")
                        .WithMany("UserLogins")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__UserLogin__UserI__25869641");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MealsV2.Models.UserMeal", b =>
                {
                    b.HasOne("MealsV2.Models.MainCat", "MainCat")
                        .WithMany("UserMeals")
                        .HasForeignKey("MainCatId")
                        .HasConstraintName("FK__UserMeals__MainC__30F848ED");

                    b.HasOne("MealsV2.Models.Meal", "Meal")
                        .WithMany("UserMeals")
                        .HasForeignKey("MealId")
                        .IsRequired()
                        .HasConstraintName("FK__UserMeals__MealI__300424B4");

                    b.HasOne("MealsV2.Models.UserDatum", "User")
                        .WithMany("UserMeals")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK__UserMeals__UserI__2F10007B");

                    b.Navigation("MainCat");

                    b.Navigation("Meal");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MealsV2.Models.FoodCat", b =>
                {
                    b.Navigation("Meals");
                });

            modelBuilder.Entity("MealsV2.Models.MainCat", b =>
                {
                    b.Navigation("UserMeals");
                });

            modelBuilder.Entity("MealsV2.Models.Meal", b =>
                {
                    b.Navigation("UserMeals");
                });

            modelBuilder.Entity("MealsV2.Models.UserDatum", b =>
                {
                    b.Navigation("UserLogins");

                    b.Navigation("UserMeals");
                });
#pragma warning restore 612, 618
        }
    }
}
