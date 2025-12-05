using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataAccessService.Domain.Entities.Ref;

namespace DataAccessService.InfrastructurePostgres.Persistence.Configurations.RefConfigurations
{
    public class ListTestTypeConfiguration : IEntityTypeConfiguration<List_test_type>
    {
        public void Configure(EntityTypeBuilder<List_test_type> entity)
        {
            entity.ToTable("list_test_type", "ref");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Mnemonic)
                .HasColumnName("mnemonic")
                .IsRequired();

            entity.HasIndex(e => e.Mnemonic).IsUnique();

            entity.Property(e => e.Code)
                .HasColumnName("code");

            entity.HasIndex(e => e.Code);

            entity.Property(e => e.Name)
                .HasColumnName("name")
                .IsRequired();

            entity.Property(e => e.Category)
                .HasColumnName("category");

            entity.Property(e => e.Description)
                .HasColumnName("description")
                .IsRequired(false);
        }
    }
}