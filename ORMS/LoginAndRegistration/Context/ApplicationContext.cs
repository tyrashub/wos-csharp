using Microsoft.EntityFrameworkCore;
using LoginAndRegistration.Models;

namespace LoginAndRegistration.Context;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public ApplicationContext(DbContextOptions options) : base(options) { }
}