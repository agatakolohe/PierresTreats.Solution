using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Inventory.Models
{
    public class InventoryContext : IdentityDbContext<ApplicationUser>
    {


        // public InventoryContext(DbContextOptions options) : base(options) { }
    }
}