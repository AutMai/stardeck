using Microsoft.EntityFrameworkCore;
using CrewModel.Entities;

namespace CrewModel.Configurations;

public class TestDbContext : DbContext {
    public DbSet<Entity> Entities { get; set; }

    public TestDbContext(DbContextOptions<TestDbContext> options) : base(options) {
    }

    protected override void OnModelCreating(ModelBuilder builder) {
    }
}