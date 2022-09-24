using MaintenanceModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace MaintenanceModel.Configurations;

public partial class MaintenanceContext : DbContext {
    public MaintenanceContext() {
    }

    public MaintenanceContext(DbContextOptions<MaintenanceContext> options)
        : base(options) {
    }

    public virtual DbSet<EStatus> EStatuses { get; set; } = null!;
    public virtual DbSet<EnergySystem> EnergySystems { get; set; } = null!;
    public virtual DbSet<GravitationSystem> GravitationSystems { get; set; } = null!;
    public virtual DbSet<Inventory> Inventories { get; set; } = null!;
    public virtual DbSet<LifeSupportSystem> LifeSupportSystems { get; set; } = null!;
    public virtual DbSet<Room> Rooms { get; set; } = null!;
    public virtual DbSet<ShipInfo> ShipInfos { get; set; } = null!;
    public virtual DbSet<Entities.System> Systems { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<EStatus>(entity => {
            entity.HasKey(e => e.Label)
                .HasName("PRIMARY");

            entity.ToTable("e_status");

            entity.Property(e => e.Label)
                .HasMaxLength(45)
                .HasColumnName("LABEL");
        });

        modelBuilder.Entity<EnergySystem>(entity => { entity.ToTable("energy_systems"); });

        modelBuilder.Entity<GravitationSystem>(entity => { entity.ToTable("gravitation_systems"); });

        modelBuilder.Entity<Inventory>(entity => {
            entity.HasKey(e => e.RessourceId)
                .HasName("PRIMARY");

            entity.ToTable("inventory");

            entity.HasIndex(e => e.RoomId, "fk_INVENTORY_ROOMS1_idx");

            entity.Property(e => e.RessourceId).HasColumnName("RESSOURCE_ID");

            entity.Property(e => e.Amount).HasColumnName("AMOUNT");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("NAME");

            entity.Property(e => e.RoomId).HasColumnName("ROOM_ID");

            entity.HasOne(d => d.Room)
                .WithMany(p => p.Inventories)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_INVENTORY_ROOMS1");
        });

        modelBuilder.Entity<LifeSupportSystem>(entity => { entity.ToTable("life_support_systems"); });

        modelBuilder.Entity<Room>(entity => {
            entity.ToTable("rooms");

            entity.HasIndex(e => e.ShipId, "fk_ROOMS_SHIP_INFO1_idx");

            entity.Property(e => e.RoomId).HasColumnName("ROOM_ID");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("NAME");

            entity.Property(e => e.ShipId).HasColumnName("SHIP_ID");

            entity.HasOne(d => d.Ship)
                .WithMany(p => p.Rooms)
                .HasForeignKey(d => d.ShipId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ROOMS_SHIP_INFO1");
        });

        modelBuilder.Entity<ShipInfo>(entity => {
            entity.HasKey(e => e.ShipId)
                .HasName("PRIMARY");

            entity.ToTable("ship_info");

            entity.Property(e => e.ShipId).HasColumnName("SHIP_ID");

            entity.Property(e => e.CurrentLocation)
                .HasMaxLength(255)
                .HasColumnName("CURRENT_LOCATION");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<Entities.System>(entity => {
            entity.HasKey(s => s.SystemId)
                .HasName("PRIMARY");
            
            entity.ToTable("systems");

            entity.HasIndex(e => e.Status, "fk_SYSTEMS_E_STATUS_idx");

            entity.HasIndex(e => e.ShipId, "fk_SYSTEMS_SHIP_INFO1_idx");

            entity.Property(e => e.SystemId).HasColumnName("SYSTEM_ID");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("NAME");

            entity.Property(e => e.ShipId).HasColumnName("SHIP_ID");

            entity.Property(e => e.Status)
                .HasMaxLength(45)
                .HasColumnName("STATUS");

            entity.HasOne(d => d.Ship)
                .WithMany(p => p.Systems)
                .HasForeignKey(d => d.ShipId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_SYSTEMS_SHIP_INFO1");

            entity.HasOne(d => d.StatusNavigation)
                .WithMany(p => p.Systems)
                .HasForeignKey(d => d.Status)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_SYSTEMS_E_STATUS");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}