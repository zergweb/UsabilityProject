using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsabilityProject.Model
{
    public class AppDbContext:DbContext
    {      
        public DbSet<AppRole> Roles { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Sample> Samples { get; set; }
        public DbSet<SampleDate> SampleDates { get; set; }
        public DbSet<Department> Departments { get; set; }
        public AppDbContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .UseMySql("server=localhost;port=3306;database=usability_project;uid=root;password=1234;",
            b => b.MigrationsAssembly("UsabilityProject")
            );
        }
    }
}
