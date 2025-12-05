using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataAccessService.Domain.Entities.Import;

namespace DataAccessService.InfrastructurePostgres.Persistence.Configurations.ImportConfigurations
{
    public class RawFileEntityLinkConfiguration : IEntityTypeConfiguration<Raw_file_entity_link>
    {
        public void Configure(EntityTypeBuilder<Raw_file_entity_link> entity)
        {
            entity.ToTable("raw_file_entity_link", "import");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Link_raw_file).HasColumnName("link_raw_file");
            entity.HasIndex(e => e.Link_raw_file);

            entity.Property(e => e.Entity_schema)
                .HasColumnName("entity_schema")
                .IsRequired();

            entity.Property(e => e.Entity_name)
                .HasColumnName("entity_name")
                .IsRequired();

            entity.Property(e => e.Object_id).HasColumnName("object_id");
            entity.HasIndex(e => e.Object_id);

            entity.Property(e => e.Created_at).HasColumnName("created_at");
        }
    }
}