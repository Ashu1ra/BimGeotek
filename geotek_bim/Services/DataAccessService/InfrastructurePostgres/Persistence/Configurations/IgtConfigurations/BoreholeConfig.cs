using DataAccessService.Domain.Entities.Igt;
using DataAccessService.InfrastructurePostgres.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessService.InfrastructurePostgres.Persistence.Configurations.IgtConfigurations
{
    public class BoreholeConfiguration : IEntityTypeConfiguration<Borehole>
    {
        public void Configure(EntityTypeBuilder<Borehole> entity)
        {
            entity.ToTable("borehole", "igt");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Link_site).HasColumnName("link_site");
            entity.HasIndex(e => e.Link_site);

            entity.OwnsOne(e => e.Location, loc =>
            {
                loc.Property(l => l.Value)
                   .HasColumnName("location")
                   .HasColumnType("geometry(PointZ,4326)")
                   .IsRequired();
            });

            entity.Property(e => e.Link_list_borehole_type).HasColumnName("link_list_borehole_type");
            entity.HasIndex(e => e.Link_list_borehole_type);

            entity.Property(e => e.Depth_min).HasColumnName("depth_min");
            entity.Property(e => e.Depth_max).HasColumnName("depth_max");

            entity.Property(e => e.Link_list_borehole_standard).HasColumnName("link_list_borehole_standard");
            entity.HasIndex(e => e.Link_list_borehole_standard);

            entity.Property(e => e.Date_start).HasColumnName("date_start");
            entity.HasIndex(e => e.Date_start);

            entity.Property(e => e.Date_end).HasColumnName("date_end");
            entity.HasIndex(e => e.Date_end);

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