using DataAccessService.Domain.Entities.Auth;
using DataAccessService.InfrastructurePostgres.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessService.InfrastructurePostgres.Persistence.Configurations.AuthConfigurations
{
    public class UserAccountConfiguration : IEntityTypeConfiguration<User_account>
    {
        public void Configure(EntityTypeBuilder<User_account> entity)
        {
            entity.ToTable("user_account", "auth");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Login)
                .HasColumnName("login")
                .IsRequired();
            entity.HasIndex(e => e.Login).IsUnique();

            entity.Property(e => e.Password)
                .HasColumnName("password_hash")
                .IsRequired();

            entity.Property(e => e.Email)
                .HasColumnName("email")
                .IsRequired();
            entity.HasIndex(e => e.Email).IsUnique();

            entity.Property(e => e.Full_name).HasColumnName("full_name");

            entity.Property(e => e.Created_at).HasColumnName("created_at");

            entity.Property(e => e.Last_login).HasColumnName("last_login");

            entity.Property(e => e.Metadata)
                .HasConversion(JsonValueConverter.Create<Dictionary<string, object>>())
                .HasColumnType("json")
                .HasColumnName("metadata");
        }
    }
}
