using Microsoft.EntityFrameworkCore;
using ChefsNDishes.Models;

namespace ChefsNDishes.Context;

public class ApplicationContext : DbContext
{
    public DbSet<Dishes> Dishes { get; set; }
    public DbSet<Chef> Chefs { get; set; }

    public ApplicationContext(DbContextOptions options) : base(options) { }
}
