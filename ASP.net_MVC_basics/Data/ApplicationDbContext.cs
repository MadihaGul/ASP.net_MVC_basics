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

             protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PeopleModel>().HasData(new PeopleModel { PersonId=1 ,Name = "Anna", Phone = "+46718899111", CityId = 1 });
            modelBuilder.Entity<PeopleModel>().HasData(new PeopleModel { PersonId = 2 ,Name = "Annika", Phone = "+46718899122", CityId = 1 });
            modelBuilder.Entity<PeopleModel>().HasData(new PeopleModel { PersonId = 3 ,Name = "Ali", Phone = "+46718894444", CityId = 2 });

            modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = 1, CityName = "Lund", CountryId= 1});
            modelBuilder.Entity<CityModel>().HasData(new CityModel { CityId = 2, CityName = "Islamabad", CountryId = 2});

            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { CountryId = 1, CountryName = "Sweden" });
            modelBuilder.Entity<CountryModel>().HasData(new CountryModel { CountryId = 2, CountryName = "Pakistan" });

        }
   
    }
}
