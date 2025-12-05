using DataAccessService.Domain.Entities.Test;
using DataAccessService.InfrastructurePostgres.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessService.InfrastructurePostgres.Persistence.Configurations.TestConfigurations
{
    public class FieldTestConfiguration : IEntityTypeConfiguration<Field_test>
    {
        public void Configure(EntityTypeBuilder<Field_test> entity)
        {
            entity.ToTable("field_test", "test");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Link_borehole_interval).HasColumnName("link_borehole_interval");
            entity.HasIndex(e => e.Link_borehole_interval);

            entity.Property(e => e.Link_list_test_type).HasColumnName("link_list_test_type");
            entity.HasIndex(e => e.Link_list_test_type);

            entity.Property(e => e.Results)
                .HasConversion(JsonValueConverter.Create<Dictionary<string, object>>())
                .HasColumnType("json")
                .HasColumnName("results");

            entity.Property(e => e.Test_date).HasColumnName("test_date");

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