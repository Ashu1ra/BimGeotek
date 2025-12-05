using DataAccessService.Domain.Entities.Ref;
using DataAccessService.InfrastructurePostgres.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessService.InfrastructurePostgres.Persistence.Configurations.RefConfigurations
{
    public class ListBoreholeIntervalTypeConfiguration : IEntityTypeConfiguration<List_borehole_interval_type>
    {
        public void Configure(EntityTypeBuilder<List_borehole_interval_type> entity)
        {
            entity.ToTable("list_borehole_interval_type", "ref");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Mnemonic)
                .HasColumnName("mnemonic")
                .IsRequired();

            entity.HasIndex(e => e.Mnemonic).IsUnique();

            entity.Property(e => e.Name)
                .HasColumnName("name")
                .IsRequired();

            entity.Property(e => e.Metadata)
                .HasConversion(JsonValueConverter.Create<Dictionary<string, object>>())
                .HasColumnType("json")
                .HasColumnName("metadata")
                .IsRequired(false);

            entity.Property(e => e.Description)
                .HasColumnName("description")
                .IsRequired(false);
        }
    }
}
