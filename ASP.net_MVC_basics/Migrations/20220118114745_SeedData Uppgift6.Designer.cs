﻿// <auto-generated />
using ASP.net_MVC_basics.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ASP.net_MVC_basics.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220118114745_SeedData Uppgift6")]
    partial class SeedDataUppgift6
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ASP.net_MVC_basics.Data.CityModel", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.HasKey("CityId");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            CityId = 1,
                            CityName = "Lund",
                            CountryId = 1
                        },
                        new
                        {
                            CityId = 2,
                            CityName = "Islamabad",
                            CountryId = 2
                        });
                });

            modelBuilder.Entity("ASP.net_MVC_basics.Data.CountryModel", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("CountryId");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            CountryId = 1,
                            CountryName = "Sweden"
                        },
                        new
                        {
                            CountryId = 2,
                            CountryName = "Pakistan"
                        });
                });

            modelBuilder.Entity("ASP.net_MVC_basics.Data.LanguageModel", b =>
                {
                    b.Property<int>("LanguageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LanguageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("LanguageId");

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            LanguageId = 1,
                            LanguageName = "English"
                        },
                        new
                        {
                            LanguageId = 2,
                            LanguageName = "Swedish"
                        },
                        new
                        {
                            LanguageId = 3,
                            LanguageName = "Urdu"
                        },
                        new
                        {
                            LanguageId = 4,
                            LanguageName = "Arabic"
                        },
                        new
                        {
                            LanguageId = 5,
                            LanguageName = "French"
                        });
                });

            modelBuilder.Entity("ASP.net_MVC_basics.Data.PeopleLanguageModel", b =>
                {
                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("LanguageId", "PersonId");

                    b.HasIndex("PersonId");

                    b.ToTable("PeopleLanguage");

                    b.HasData(
                        new
                        {
                            LanguageId = 1,
                            PersonId = 1
                        },
                        new
                        {
                            LanguageId = 2,
                            PersonId = 1
                        },
                        new
                        {
                            LanguageId = 1,
                            PersonId = 2
                        },
                        new
                        {
                            LanguageId = 4,
                            PersonId = 3
                        },
                        new
                        {
                            LanguageId = 1,
                            PersonId = 3
                        });
                });

            modelBuilder.Entity("ASP.net_MVC_basics.Data.PeopleModel", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(13)")
                        .HasMaxLength(13);

                    b.HasKey("PersonId");

                    b.HasIndex("CityId");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            PersonId = 1,
                            CityId = 1,
                            Name = "Anna",
                            Phone = "+46718899111"
                        },
                        new
                        {
                            PersonId = 2,
                            CityId = 1,
                            Name = "Annika",
                            Phone = "+46718899122"
                        },
                        new
                        {
                            PersonId = 3,
                            CityId = 2,
                            Name = "Ali",
                            Phone = "+46718894444"
                        });
                });

            modelBuilder.Entity("ASP.net_MVC_basics.Data.CityModel", b =>
                {
                    b.HasOne("ASP.net_MVC_basics.Data.CountryModel", "Country")
                        .WithMany("listCity")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ASP.net_MVC_basics.Data.PeopleLanguageModel", b =>
                {
                    b.HasOne("ASP.net_MVC_basics.Data.LanguageModel", "Language")
                        .WithMany("PeopleLanguages")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ASP.net_MVC_basics.Data.PeopleModel", "Person")
                        .WithMany("PeopleLanguages")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ASP.net_MVC_basics.Data.PeopleModel", b =>
                {
                    b.HasOne("ASP.net_MVC_basics.Data.CityModel", "City")
                        .WithMany("listPeople")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
