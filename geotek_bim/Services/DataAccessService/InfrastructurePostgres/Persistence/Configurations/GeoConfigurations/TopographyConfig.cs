using DataAccessService.Domain.Entities.Geo;
using DataAccessService.InfrastructurePostgres.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessService.InfrastructurePostgres.Persistence.Configurations.GeoConfigurations
{
    public class TopographyConfiguration : IEntityTypeConfiguration<Topography>
    {
        public void Configure(EntityTypeBuilder<Topography> entity)
        {
            entity.ToTable("topography", "geo");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Link_site).HasColumnName("link_site");
            entity.HasIndex(e => e.Link_site);

            entity.Property(e => e.Link_data_source).HasColumnName("link_data_source");
            entity.HasIndex(e => e.Link_data_source);

            entity.OwnsOne(e => e.Area, area =>
            {
                area.Property(a => a.Value)
                    .HasColumnName("area")
                    .HasColumnType("geometry(Polygon,4326)")
                    .IsRequired();
            });

            entity.Property(e => e.Raster_file).HasColumnName("raster_file");

            entity.Property(e => e.Metadata)
                .HasConversion(JsonValueConverter.Create<Dictionary<string, object>>())
                .HasColumnType("json")
                .HasColumnName("metadata")
                .IsRequired(false);

            entity.Property(e => e.Created_at).HasColumnName("created_at");
            entity.HasIndex(e => e.Created_at);

            entity.Property(e => e.Updated_at).HasColumnName("updated_at");

            entity.Property(e => e.Owner_user_id).HasColumnName("owner_user_id");
            entity.HasIndex(e => e.Owner_user_id);
        }
    }
}