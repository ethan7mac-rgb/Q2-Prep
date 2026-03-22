using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz2_LINQ;

public class Context : DbContext
{
    //These DBSet collection are how we will access the data from the database
    //LINQ queries against these collections get translated into queries against the database.
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Address> Addresses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["Quiz2DB"].ConnectionString);
        optionsBuilder.EnableSensitiveDataLogging();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Here is fluent API to set properties for our database
        //EF will infer what it can, but you may need to set Keys, datatypes, etc. here
        //This can also be handled through Data Annotations as well
        modelBuilder.Entity<Order>(o =>
        {
            o.HasKey(o => o.OrderID);
            o.HasOne(o => o.SalesRep);
        });
        modelBuilder.Entity<Customer>(c =>
        {
            c.HasMany(c => c.Orders)
            .WithOne(o => o.Customer)
            .OnDelete(DeleteBehavior.NoAction);
        });
    }
}
