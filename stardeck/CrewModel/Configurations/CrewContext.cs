using CrewModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrewModel.Configurations; 

public partial class CrewContext : DbContext
{
    public CrewContext()
    {
    }

    public CrewContext(DbContextOptions<CrewContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Commander> Commanders { get; set; } = null!;
    public virtual DbSet<Crew> Crews { get; set; } = null!;
    public virtual DbSet<Droid> Droids { get; set; } = null!;
    public virtual DbSet<Guard> Guards { get; set; } = null!;
    public virtual DbSet<Logbook> Logbooks { get; set; } = null!;
    public virtual DbSet<Mechanic> Mechanics { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            optionsBuilder.UseMySql("server=localhost;port=3306;database=stardeck;user=root;password=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Commander>(entity =>
        {
            entity.HasKey(e => e.CrewMemberId)
                .HasName("PRIMARY");

            entity.ToTable("commanders");

            entity.Property(e => e.CrewMemberId)
                .ValueGeneratedNever()
                .HasColumnName("CREW_MEMBER_ID");

            entity.HasOne(d => d.CrewMember)
                .WithOne(p => p.Commander)
                .HasForeignKey<Commander>(d => d.CrewMemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_COMMANDERS_CREW1");
        });

        modelBuilder.Entity<Crew>(entity =>
        {
            entity.HasKey(e => e.CrewMemberId)
                .HasName("PRIMARY");

            entity.ToTable("crew");

            entity.Property(e => e.CrewMemberId).HasColumnName("CREW_MEMBER_ID");

            entity.Property(e => e.Health).HasColumnName("HEALTH");
        });

        modelBuilder.Entity<Droid>(entity =>
        {
            entity.HasKey(e => e.CrewCrewMemberId)
                .HasName("PRIMARY");

            entity.ToTable("droids");

            entity.Property(e => e.CrewCrewMemberId)
                .ValueGeneratedNever()
                .HasColumnName("CREW_CREW_MEMBER_ID");

            entity.HasOne(d => d.CrewCrewMember)
                .WithOne(p => p.Droid)
                .HasForeignKey<Droid>(d => d.CrewCrewMemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_DROIDS_CREW1");
        });

        modelBuilder.Entity<Guard>(entity =>
        {
            entity.HasKey(e => e.CrewMemberId)
                .HasName("PRIMARY");

            entity.ToTable("guards");

            entity.Property(e => e.CrewMemberId)
                .ValueGeneratedNever()
                .HasColumnName("CREW_MEMBER_ID");

            entity.HasOne(d => d.CrewMember)
                .WithOne(p => p.Guard)
                .HasForeignKey<Guard>(d => d.CrewMemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_GUARDS_CREW1");
        });

        modelBuilder.Entity<Logbook>(entity =>
        {
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

        modelBuilder.Entity<Mechanic>(entity =>
        {
            entity.HasKey(e => e.CrewMemberId)
                .HasName("PRIMARY");

            entity.ToTable("mechanics");

            entity.Property(e => e.CrewMemberId)
                .ValueGeneratedNever()
                .HasColumnName("CREW_MEMBER_ID");

            entity.HasOne(d => d.CrewMember)
                .WithOne(p => p.Mechanic)
                .HasForeignKey<Mechanic>(d => d.CrewMemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_MECHANICS_CREW1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}