using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Context;



public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> options):base(options)
    {

    }
protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.Entity<Product>()
            .HasOne<Customer>(s => s.Customers)
            .WithMany(g => g.Products)
            .HasForeignKey(s => s.CustomerId);

       modelBuilder.Entity<Installment>()
            .HasOne<Product>(s => s.Products)
            .WithMany(g => g.Installments)
            .HasForeignKey(s => s.ProductId);
             
    }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Installment> Installments { get; set; }
    //public DbSet<Order> Orders  { get; set; }
}