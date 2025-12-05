using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataAccessService.Domain.Entities.Auth;

namespace DataAccessService.InfrastructurePostgres.Persistence.Configurations.AuthConfigurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<User_role>
    {
        public void Configure(EntityTypeBuilder<User_role> entity)
        {
            entity.ToTable("user_role", "auth");

            entity.HasKey(e => new { e.Link_user_account, e.Link_role_list });

            entity.Property(e => e.Link_user_account).HasColumnName("link_user_account");
            entity.HasIndex(e => e.Link_user_account);

            entity.Property(e => e.Link_role_list).HasColumnName("link_role_list");
            entity.HasIndex(e => e.Link_role_list);
        }
    }
}
