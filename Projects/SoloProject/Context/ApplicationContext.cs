using SoloProject.Models;
using Microsoft.EntityFrameworkCore;

namespace SoloProject.Context;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Collection> Collections { get; set; }
    public DbSet<Engagement> Engagements { get; set; }
    public ApplicationContext(DbContextOptions options) : base(options) { }
}
