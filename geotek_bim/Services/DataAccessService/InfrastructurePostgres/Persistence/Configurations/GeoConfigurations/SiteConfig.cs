using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataAccessService.Domain.Entities.Geo;

namespace DataAccessService.InfrastructurePostgres.Persistence.Configurations.GeoConfigurations
{
    public class SiteConfiguration : IEntityTypeConfiguration<Site>
    {
        public void Configure(EntityTypeBuilder<Site> entity)
        {
            entity.ToTable("site", "geo");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Link_project).HasColumnName("link_project");
            entity.HasIndex(e => e.Link_project);

            entity.Property(e => e.Name)
                .HasColumnName("name")
                .IsRequired();

            entity.OwnsOne(e => e.Area, area =>
            {
                area.Property(a => a.Value)
                    .HasColumnName("area")
                    .HasColumnType("geometry(Polygon,4326)")
                    .IsRequired();
            });

            entity.Property(e => e.Description).HasColumnName("description");

            entity.Property(e => e.Created_at).HasColumnName("created_at");
            entity.HasIndex(e => e.Created_at);

            entity.Property(e => e.Updated_at).HasColumnName("updated_at");

            entity.Property(e => e.Owner_user_id).HasColumnName("owner_user_id");
            entity.HasIndex(e => e.Owner_user_id);
        }
    }
}