using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataAccessService.Domain.Entities.Import;

namespace DataAccessService.InfrastructurePostgres.Persistence.Configurations.ImportConfigurations
{
    public class DataSourceConfiguration : IEntityTypeConfiguration<Data_source>
    {
        public void Configure(EntityTypeBuilder<Data_source> entity)
        {
            entity.ToTable("data_source", "import");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Name)
                .HasColumnName("name")
                .IsRequired();

            entity.Property(e => e.Link_list_source_type).HasColumnName("link_list_source_type");

            entity.HasIndex(e => e.Link_list_source_type);

            entity.Property(e => e.Source_link).HasColumnName("source_link");

            entity.Property(e => e.Description).HasColumnName("description");

            entity.Property(e => e.Owner_user_id).HasColumnName("owner_user_id");

            entity.HasIndex(e => e.Owner_user_id);
        }
    }
}