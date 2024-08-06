using Microsoft.EntityFrameworkCore;
using CRUDelicious.Models;

namespace CRUDelicious.Context;

public class ApplicationContext : DbContext
{
    public DbSet<Dishes> Dishes { get; set; }

    public ApplicationContext(DbContextOptions options) : base(options) { }

}