#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace CRUDelicious.Models;

public class DishContext : DbContext 
{
    public DishContext(DbContextOptions options) : base(options) { }
    // the "Dishes" table name will come from the DbSet property name
    
    public DbSet<Dish> Dishes { get; set; }
}