using DataAccessService.Domain.Entities.Geo;
using DataAccessService.InfrastructurePostgres.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessService.InfrastructurePostgres.Persistence.Configurations.GeoConfigurations
{
    public class BimModelConfiguration : IEntityTypeConfiguration<Bim_model>
    {
        public void Configure(EntityTypeBuilder<Bim_model> entity)
        {
            entity.ToTable("bim_model", "geo");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Link_site).HasColumnName("link_site");
            entity.HasIndex(e => e.Link_site);

            entity.Property(e => e.Format).HasColumnName("format");

            entity.OwnsOne(e => e.Area, area =>
            {
                area.Property(a => a.Value)
                    .HasColumnName("area")
                    .HasColumnType("geometry(Polygon,4326)")
                    .IsRequired();
            });

            entity.Property(e => e.File_data).HasColumnName("file_data");

            entity.Property(e => e.Metadata)
                .HasConversion(JsonValueConverter.Create<Dictionary<string, object>>())
                .HasColumnType("json")
                .HasColumnName("metadata")
                .IsRequired(false);

            entity.Property(e => e.Created_at).HasColumnName("created_at");
            entity.HasIndex(e => e.Created_at);

            entity.Property(e => e.Updated_at).HasColumnName("updated_at");
        }
    }
}