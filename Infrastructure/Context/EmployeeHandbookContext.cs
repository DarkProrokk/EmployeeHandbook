using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class EmployeeHandbookContext : DbContext
    {
        public EmployeeHandbookContext(DbContextOptions<EmployeeHandbookContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Employees");

                entity.Property(e => e.FullName);
                entity.Property(e => e.BirthDay);
                entity.Property(e => e.Sex);
            });
        }
    }
}

