using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataAccessService.Domain.Entities.Igt;

namespace DataAccessService.InfrastructurePostgres.Persistence.Configurations.IgtConfigurations
{
    public class SampleConfiguration : IEntityTypeConfiguration<Sample>
    {
        public void Configure(EntityTypeBuilder<Sample> entity)
        {
            entity.ToTable("sample", "igt");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Link_borehole_interval).HasColumnName("link_borehole_interval");
            entity.HasIndex(e => e.Link_borehole_interval);

            entity.Property(e => e.Number).HasColumnName("number").IsRequired();
            entity.HasIndex(e => e.Number).IsUnique();

            entity.OwnsOne(e => e.Interval, interval =>
            {
                interval.Property(i => i.From)
                        .HasColumnName("depth_from")
                        .IsRequired();
                interval.Property(i => i.To)
                        .HasColumnName("depth_to")
                        .IsRequired();

                interval.HasIndex(i => i.From);
                interval.HasIndex(i => i.To);
            });

            entity.Property(e => e.Link_list_sample_standard).HasColumnName("link_list_sample_standard");
            entity.HasIndex(e => e.Link_list_sample_standard);

            entity.Property(e => e.Description).HasColumnName("description");

            entity.Property(e => e.Created_at).HasColumnName("created_at");
            entity.HasIndex(e => e.Created_at);

            entity.Property(e => e.Updated_at).HasColumnName("updated_at");

            entity.Property(e => e.Owner_user_id).HasColumnName("owner_user_id");
            entity.HasIndex(e => e.Owner_user_id);
        }
    }
}