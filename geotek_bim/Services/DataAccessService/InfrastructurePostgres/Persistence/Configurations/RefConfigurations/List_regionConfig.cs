using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataAccessService.Domain.Entities.Ref;

namespace DataAccessService.InfrastructurePostgres.Persistence.Configurations.RefConfigurations
{
    public class ListRegionConfiguration : IEntityTypeConfiguration<List_region>
    {
        public void Configure(EntityTypeBuilder<List_region> entity)
        {
            entity.ToTable("list_region", "ref");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Mnemonic)
                .HasColumnName("mnemonic")
                .IsRequired();

            entity.HasIndex(e => e.Mnemonic).IsUnique();

            entity.Property(e => e.Code)
                .HasColumnName("code")
                .IsRequired();

            entity.Property(e => e.Name)
                .HasColumnName("name")
                .IsRequired();
        }
    }
}
