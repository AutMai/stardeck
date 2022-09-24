using CrewModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrewModel.Configurations;

public partial class CrewContext : DbContext {
    public CrewContext() {
    }

    public CrewContext(DbContextOptions<CrewContext> options)
        : base(options) {
    }

    public virtual DbSet<Commander> Commanders { get; set; } = null!;
    public virtual DbSet<Crew> Crews { get; set; } = null!;
    public virtual DbSet<Droid> Droids { get; set; } = null!;
    public virtual DbSet<Guard> Guards { get; set; } = null!;
    public virtual DbSet<Logbook> Logbooks { get; set; } = null!;
    public virtual DbSet<Mechanic> Mechanics { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Commander>(entity => { entity.ToTable("commanders"); });

        modelBuilder.Entity<Crew>(entity => {
            entity.HasKey(e => e.CrewMemberId)
                .HasName("PRIMARY");

            entity.ToTable("crew");

            entity.Property(e => e.CrewMemberId).HasColumnName("CREW_MEMBER_ID");

            entity.Property(e => e.Health).HasColumnName("HEALTH");
        });

        modelBuilder.Entity<Droid>(entity => { entity.ToTable("droids"); });

        modelBuilder.Entity<Guard>(entity => { entity.ToTable("guards"); });

        modelBuilder.Entity<Logbook>(entity => {
            entity.HasKey(e => e.LogId)
                .HasName("PRIMARY");

            entity.ToTable("logbook");

            entity.HasIndex(e => e.AuthorMemberId, "fk_LOGBOOK_CREW1_idx");

            entity.Property(e => e.LogId).HasColumnName("LOG_ID");

            entity.Property(e => e.AuthorMemberId).HasColumnName("AUTHOR_MEMBER_ID");

            entity.Property(e => e.Content)
                .HasColumnType("text")
                .HasColumnName("CONTENT");

            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("TITLE");

            entity.HasOne(d => d.AuthorMember)
                .WithMany(p => p.Logbooks)
                .HasForeignKey(d => d.AuthorMemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_LOGBOOK_CREW1");
        });

        modelBuilder.Entity<Mechanic>(entity => { entity.ToTable("mechanics"); });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}