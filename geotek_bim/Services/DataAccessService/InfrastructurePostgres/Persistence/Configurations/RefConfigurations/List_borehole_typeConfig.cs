using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataAccessService.Domain.Entities.Ref;

namespace DataAccessService.InfrastructurePostgres.Persistence.Configurations.RefConfigurations
{
    public class ListBoreholeTypeConfiguration : IEntityTypeConfiguration<List_borehole_type>
    {
        public void Configure(EntityTypeBuilder<List_borehole_type> entity)
        {
            entity.ToTable("list_borehole_type", "ref");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Mnemonic)
                .HasColumnName("mnemonic")
                .IsRequired();

            entity.HasIndex(e => e.Mnemonic).IsUnique();

            entity.Property(e => e.Name)
                .HasColumnName("name")
                .IsRequired();

            entity.Property(e => e.Description)
                .HasColumnName("description")
                .IsRequired(false);
        }
    }
}
