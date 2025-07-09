using System;
using Microsoft.EntityFrameworkCore;
using Practice.Entities;

namespace Practice.Data;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>().HasData(
            new Address()
            {
                Id = 1,
                Country = "Indonesia",
                City = "Serang",
                PostalCode = "351121"
            },
            new Address()
            {
                Id = 2,
                Country = "Thailand",
                City = "Bangkok",
                PostalCode = "123113"
            },
            new Address()
            {
                Id = 3,
                Country = "Indonesia",
                City = "Jakarta",
                PostalCode = "234232"
            }
        );
    }

    public DbSet<Person> Persons { get; set; }
    public DbSet<Address> Addresses { get; set; }
}
