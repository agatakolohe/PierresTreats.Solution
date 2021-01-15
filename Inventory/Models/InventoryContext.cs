using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Inventory.Models
{
    public class InventoryContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Flavor> Flavors { get; set; }
        public DbSet<Treat> Treats { get; set; }
        public DbSet<FlavorTreat> FlavorTreat { get; set; }
        public InventoryContext(DbContextOptions options) : base(options) { }
    }
}