using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataAccessService.Domain.Entities.Auth;

namespace DataAccessService.InfrastructurePostgres.Persistence.Configurations.AuthConfigurations
{
    public class UserGroupConfiguration : IEntityTypeConfiguration<User_group>
    {
        public void Configure(EntityTypeBuilder<User_group> entity)
        {
            entity.ToTable("user_group", "auth");

            entity.HasKey(e => new { e.Link_user_account, e.Link_group_list });

            entity.Property(e => e.Link_user_account).HasColumnName("link_user_account");
            entity.Property(e => e.Link_group_list).HasColumnName("link_group_list");
        }
    }
}