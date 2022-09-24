using Microsoft.EntityFrameworkCore;
using NavigationModel.Entities;

namespace NavigationModel.Configurations {
    public partial class NavigationContext : DbContext {
        public NavigationContext() {
        }

        public NavigationContext(DbContextOptions<NavigationContext> options)
            : base(options) {
        }

        public virtual DbSet<Galaxy> Galaxies { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<Planet> Planets { get; set; } = null!;
        public virtual DbSet<Route> Routes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Galaxy>(entity => {
                entity.ToTable("galaxies");
            });

            modelBuilder.Entity<Location>(entity => {
                entity.ToTable("locations");

                entity.Property(e => e.LocationId).HasColumnName("LOCATION_ID");

                entity.Property(e => e.CoordX)
                    .HasPrecision(5, 2)
                    .HasColumnName("COORD_X");

                entity.Property(e => e.CoordY)
                    .HasPrecision(5, 2)
                    .HasColumnName("COORD_Y");

                entity.Property(e => e.CoordZ)
                    .HasPrecision(5, 2)
                    .HasColumnName("COORD_Z");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<Planet>(entity => {
                entity.ToTable("planets");

                entity.HasIndex(e => e.GalaxyId, "fk_PLANETS_GALAXIES1_idx");

                entity.Property(e => e.GalaxyId).HasColumnName("GALAXY_ID");

                entity.Property(e => e.IsExoplanet).HasColumnName("IS_EXOPLANET");

                entity.HasOne(d => d.Galaxy)
                    .WithMany(p => p.Planets)
                    .HasForeignKey(d => d.GalaxyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_PLANETS_GALAXIES1");
            });

            modelBuilder.Entity<Route>(entity => {
                entity.ToTable("routes");

                entity.HasIndex(e => e.FromLocationId, "fk_ROUTES_LOCATIONS1_idx");

                entity.HasIndex(e => e.ToLocationId, "fk_ROUTES_LOCATIONS2_idx");

                entity.Property(e => e.RouteId).HasColumnName("ROUTE_ID");

                entity.Property(e => e.FlightTime).HasColumnName("FLIGHT_TIME");

                entity.Property(e => e.FromLocationId).HasColumnName("FROM_LOCATION_ID");

                entity.Property(e => e.FuelCost)
                    .HasPrecision(10, 2)
                    .HasColumnName("FUEL_COST");

                entity.Property(e => e.IsHypergate).HasColumnName("IS_HYPERGATE");

                entity.Property(e => e.Length)
                    .HasPrecision(10, 2)
                    .HasColumnName("LENGTH");

                entity.Property(e => e.ToLocationId).HasColumnName("TO_LOCATION_ID");

                entity.HasOne(d => d.FromLocation)
                    .WithMany(p => p.RoutesFromThisLocation)
                    .HasForeignKey(d => d.FromLocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ROUTES_LOCATIONS1");

                entity.HasOne(d => d.ToLocation)
                    .WithMany(p => p.RouteToThisLocation)
                    .HasForeignKey(d => d.ToLocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ROUTES_LOCATIONS2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}