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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PeopleModel>().HasData(new PeopleModel { PersonId=1 ,Name = "Anna", Phone = "+46718899111", City = "Stockholm" });
            modelBuilder.Entity<PeopleModel>().HasData(new PeopleModel { PersonId = 2 ,Name = "Annika", Phone = "+46718899122", City = "Lund" });
            modelBuilder.Entity<PeopleModel>().HasData(new PeopleModel { PersonId = 3 ,Name = "Ali", Phone = "+46718894444", City = "Uppsala" });

        }
    }
}
