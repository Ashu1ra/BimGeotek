using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataAccessService.Domain.Entities.Auth;
using DataAccessService.InfrastructurePostgres.Converters;

namespace DataAccessService.InfrastructurePostgres.Persistence.Configurations.AuthConfigurations
{
    public class AccessControlConfiguration : IEntityTypeConfiguration<Access_control>
    {
        public void Configure(EntityTypeBuilder<Access_control> entity)
        {
            entity.ToTable("access_control", "auth");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Entity_schema).HasColumnName("entity_schema");
            entity.Property(e => e.Entity_name).HasColumnName("entity_name");
            entity.Property(e => e.Object_id).HasColumnName("object_id");
            entity.HasIndex(e => e.Object_id);

            entity.Property(e => e.Link_user_account).HasColumnName("link_user_account");
            entity.HasIndex(e => e.Link_user_account);

            entity.Property(e => e.Link_group_list).HasColumnName("link_group_list");
            entity.HasIndex(e => e.Link_group_list);

            entity.Property(e => e.Link_role_list).HasColumnName("link_role_list");
            entity.HasIndex(e => e.Link_role_list);

            entity.Property(e => e.Can_read).HasColumnName("can_read");
            entity.Property(e => e.Can_write).HasColumnName("can_write");
            entity.Property(e => e.Can_delete).HasColumnName("can_delete");

            entity.Property(e => e.Metadata)
                .HasConversion(JsonValueConverter.Create<Dictionary<string, object>>())
                .HasColumnType("json")
                .HasColumnName("metadata");
        }
    }
}