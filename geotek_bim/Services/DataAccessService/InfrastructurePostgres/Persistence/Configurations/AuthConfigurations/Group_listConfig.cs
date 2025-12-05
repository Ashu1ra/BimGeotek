using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataAccessService.Domain.Entities.Auth;

namespace DataAccessService.InfrastructurePostgres.Persistence.Configurations.AuthConfigurations
{
    public class GroupListConfiguration : IEntityTypeConfiguration<Group_list>
    {
        public void Configure(EntityTypeBuilder<Group_list> entity)
        {
            entity.ToTable("group_list", "auth");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Name)
                .HasColumnName("name")
                .IsRequired();
            entity.HasIndex(e => e.Name).IsUnique();

            entity.Property(e => e.Description).HasColumnName("description");
        }
    }
}