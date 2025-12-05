using DataAccessService.Domain.Entities.Audit;
using DataAccessService.InfrastructurePostgres.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessService.InfrastructurePostgres.Persistence.Configurations.AuditConfigurations
{
    public class LogSampleConfiguration : IEntityTypeConfiguration<Log_sample>
    {
        public void Configure(EntityTypeBuilder<Log_sample> entity)
        {
            entity.ToTable("log_sample", "audit");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Link_sample).HasColumnName("link_sample");
            entity.HasIndex(e => e.Link_sample);

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