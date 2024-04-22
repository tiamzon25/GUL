using GUL.Persistence.Initializable;
using GUL.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace GUL.Persistence.Context;

public interface IPosDbContext : IInitializable
{
    //DbSet<Category> Categories { get; set; }
    //DbSet<Customer> Customers { get; set; }
    //DbSet<Inventory> Inventories { get; set; }
    //// DbSet<Person> Persons { get; set; }
    //DbSet<Product> Products { get; set; }
    //DbSet<Models.Sale> Sales { get; set; }
    //DbSet<ShoppingCart> ShoppingCarts { get; set; }
    //DbSet<Supplier> Suppliers { get; set; }
    //DbSet<Tenant> Tenants { get; set; }
    DbSet<AuditLog> AuditLogs { get; set; }
}
// Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

