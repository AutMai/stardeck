using Microsoft.EntityFrameworkCore;
using NavigationModel.Entities;

namespace NavigationModel.Configurations;

public class TestDbContext : DbContext {
    public DbSet<Entity> Entities { get; set; }

    public TestDbContext(DbContextOptions<TestDbContext> options) : base(options) {
    }

    protected override void OnModelCreating(ModelBuilder builder) {
    }
}