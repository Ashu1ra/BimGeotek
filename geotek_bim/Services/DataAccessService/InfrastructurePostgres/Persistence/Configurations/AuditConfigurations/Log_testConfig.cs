using DataAccessService.Domain.Entities.Audit;
using DataAccessService.InfrastructurePostgres.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessService.InfrastructurePostgres.Persistence.Configurations.AuditConfigurations
{
    public class LogTestConfiguration : IEntityTypeConfiguration<Log_test>
    {
        public void Configure(EntityTypeBuilder<Log_test> entity)
        {
            entity.ToTable("log_test", "audit");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Test_type).HasColumnName("test_type");

            entity.Property(e => e.Link_test).HasColumnName("link_test");
            entity.HasIndex(e => e.Link_test);

            entity.Property(e => e.Old_data)
                .HasConversion(JsonValueConverter.Create<Dictionary<string, object>>())
                .HasColumnType("json")
                .HasColumnName("old_data");

            entity.Property(e => e.Operation_type).HasColumnName("operation_type");

            entity.Property(e => e.Changed_by).HasColumnName("changed_by");

            entity.Property(e => e.Changed_at).HasColumnName("changed_at");
            entity.HasIndex(e => e.Changed_at);
        }
    }
}