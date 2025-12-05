using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataAccessService.Domain.Entities.Auth;

namespace DataAccessService.InfrastructurePostgres.Persistence.Configurations.AuthConfigurations
{
    public class RoleListConfiguration : IEntityTypeConfiguration<Role_list>
    {
        public void Configure(EntityTypeBuilder<Role_list> entity)
        {
            entity.ToTable("role_list", "auth");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Name)
                .HasColumnName("name")
                .IsRequired();

            entity.Property(e => e.Description)
                .HasColumnName("description");
        }
    }
}