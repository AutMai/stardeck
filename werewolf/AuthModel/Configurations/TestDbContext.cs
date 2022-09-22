using Microsoft.EntityFrameworkCore;
using AuthModel.Entities;

namespace AuthModel.Configurations;

public class TestDbContext : DbContext {
    public DbSet<Entity> Entities { get; set; }

    public TestDbContext(DbContextOptions<TestDbContext> options) : base(options) {
    }

    protected override void OnModelCreating(ModelBuilder builder) {
    }
}