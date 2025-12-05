using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataAccessService.Domain.Entities.Geo;

namespace DataAccessService.InfrastructurePostgres.Persistence.Configurations.GeoConfigurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> entity)
        {
            entity.ToTable("project", "geo");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Link_list_region).HasColumnName("link_list_region");
            entity.HasIndex(e => e.Link_list_region);

            entity.Property(e => e.Name)
                .HasColumnName("name")
                .IsRequired();
            entity.Property(e => e.Link_data_source).HasColumnName("link_data_source");

            entity.OwnsOne(e => e.Center_location, loc =>
            {
                loc.Property(l => l.Value)
                   .HasColumnName("center_location")
                   .HasColumnType("geometry(PointZ,4326)")
                   .IsRequired();
            });

            entity.OwnsOne(e => e.Area, area =>
            {
                area.Property(a => a.Value)
                    .HasColumnName("area")
                    .HasColumnType("geometry(MultiPolygon,4326)")
                    .IsRequired();
            });

            entity.Property(e => e.Date_start).HasColumnName("date_start");
            entity.Property(e => e.Description).HasColumnName("description");

            entity.Property(e => e.Created_at).HasColumnName("created_at");
            entity.HasIndex(e => e.Created_at);

            entity.Property(e => e.Updated_at).HasColumnName("updated_at");
            entity.Property(e => e.Owner_user_id).HasColumnName("owner_user_id");
            entity.HasIndex(e => e.Owner_user_id);
        }
    }
}