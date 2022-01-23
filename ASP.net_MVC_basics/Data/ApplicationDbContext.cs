using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.net_MVC_basics.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<PeopleModel> People { get; set; }
        public DbSet<CityModel> Cities { get; set; }
        public DbSet<CountryModel> Countries { get; set; }
        public DbSet<LanguageModel> Languages { get; set; }
        public DbSet<PeopleLanguageModel> PeopleLanguage { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PeopleLanguageModel>().HasKey(pl => new { pl.LanguageId, pl.PersonId });

            modelBuilder.Entity<PeopleLanguageModel>()
                .HasOne(pl => pl.Language)
                .WithMany(p => p.SpokenByPeople)
                .HasForeignKey(pl => pl.LanguageId);

            modelBuilder.Entity<PeopleLanguageModel>()
                .HasOne(pl => pl.Person)
                .WithMany(l => l.SpeaksLanguages)
                .HasForeignKey(pl => pl.PersonId);

            modelBuilder.Entity<PeopleModel>().HasData(new PeopleModel { PersonId=1 ,Name = "Anna", Phone = "+46718899111", CityId = 1 });
            modelBuilder.Entity<PeopleModel>().HasData(new PeopleModel { PersonId = 2 ,Name = "Annika", Phone = "+46718899122", CityId = 1 });
            modelBuilder.Entity<PeopleModel>().HasData(new PeopleModel { PersonId = 3 ,Name = "Ali", Phone = "+46718894444", CityId = 2 });

            modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = 1, CityName = "Lund", CountryId= 1});
            modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = 2, CityName = "Islamabad", CountryId = 2});

            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { CountryId = 1, CountryName = "Sweden" });
            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { CountryId = 2, CountryName = "Pakistan" });

            modelBuilder.Entity<LanguageModel>().HasData(new LanguageModel { LanguageId=1, LanguageName="English"});
            modelBuilder.Entity<LanguageModel>().HasData(new LanguageModel { LanguageId = 2, LanguageName = "Swedish" });
            modelBuilder.Entity<LanguageModel>().HasData(new LanguageModel { LanguageId = 3, LanguageName = "Urdu" });
            modelBuilder.Entity<LanguageModel>().HasData(new LanguageModel { LanguageId = 4, LanguageName = "Arabic" });
            modelBuilder.Entity<LanguageModel>().HasData(new LanguageModel { LanguageId = 5, LanguageName = "French" });

            modelBuilder.Entity<PeopleLanguageModel>().HasData(new PeopleLanguageModel { PersonId= 1, LanguageId=1});
            modelBuilder.Entity<PeopleLanguageModel>().HasData(new PeopleLanguageModel { PersonId = 1, LanguageId = 2 });
            modelBuilder.Entity<PeopleLanguageModel>().HasData(new PeopleLanguageModel { PersonId = 2, LanguageId = 1 });
            modelBuilder.Entity<PeopleLanguageModel>().HasData(new PeopleLanguageModel { PersonId = 3, LanguageId = 4 });
            modelBuilder.Entity<PeopleLanguageModel>().HasData(new PeopleLanguageModel { PersonId = 3, LanguageId = 1 });

        }
   
    }
}
