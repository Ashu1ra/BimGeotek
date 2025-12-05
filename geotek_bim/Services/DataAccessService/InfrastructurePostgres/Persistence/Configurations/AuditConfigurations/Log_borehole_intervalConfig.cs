using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataAccessService.Domain.Entities.Audit;
using DataAccessService.InfrastructurePostgres.Converters;

namespace DataAccessService.InfrastructurePostgres.Persistence.Configurations.AuditConfigurations
{
    public class LogBoreholeIntervalConfiguration : IEntityTypeConfiguration<Log_borehole_interval>
    {
        public void Configure(EntityTypeBuilder<Log_borehole_interval> entity)
        {
            entity.ToTable("log_borehole_interval", "audit");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Link_borehole_interval).HasColumnName("link_borehole_interval");
            entity.HasIndex(e => e.Link_borehole_interval);

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