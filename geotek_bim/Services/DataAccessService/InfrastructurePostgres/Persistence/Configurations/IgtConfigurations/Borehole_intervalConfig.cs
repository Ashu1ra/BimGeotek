using DataAccessService.Domain.Entities.Igt;
using DataAccessService.InfrastructurePostgres.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessService.InfrastructurePostgres.Persistence.Configurations.IgtConfigurations
{
    public class BoreholeIntervalConfiguration : IEntityTypeConfiguration<Borehole_interval>
    {
        public void Configure(EntityTypeBuilder<Borehole_interval> entity)
        {
            entity.ToTable("borehole_interval", "igt");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Link_borehole).HasColumnName("link_borehole");
            entity.HasIndex(e => e.Link_borehole);

            entity.OwnsOne(e => e.Interval, interval =>
            {
                interval.Property(i => i.From)
                        .HasColumnName("depth_from")
                        .IsRequired();

                interval.Property(i => i.To)
                        .HasColumnName("depth_to")
                        .IsRequired();
            });

            entity.Property(e => e.Link_list_borehole_interval_type).HasColumnName("link_list_borehole_interval_type");
            entity.HasIndex(e => e.Link_list_borehole_interval_type);

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