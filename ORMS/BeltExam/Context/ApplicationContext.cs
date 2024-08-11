using BeltExam.Models;
using Microsoft.EntityFrameworkCore;

namespace BeltExam.Context;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Coupon> Coupons { get; set; }
    public DbSet<Search> Searches { get; set; }

    public ApplicationContext(DbContextOptions options) : base(options) { }
}
