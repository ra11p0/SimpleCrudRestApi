using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseAccess.DbModels;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAccess
{
    public class CarCrudDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Lorry> Lorries { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public CarCrudDbContext(DbContextOptions<CarCrudDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<Car>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<Lorry>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<Model>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<Manufacturer>().HasQueryFilter(e => !e.IsDeleted);
        }
    }
}
