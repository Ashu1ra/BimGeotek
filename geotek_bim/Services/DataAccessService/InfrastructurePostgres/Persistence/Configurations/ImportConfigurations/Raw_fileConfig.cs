using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DataAccessService.Domain.Entities.Import;

namespace DataAccessService.InfrastructurePostgres.Persistence.Configurations.ImportConfigurations
{
    public class RawFileConfiguration : IEntityTypeConfiguration<Raw_file>
    {
        public void Configure(EntityTypeBuilder<Raw_file> entity)
        {
            entity.ToTable("raw_file", "import");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Link_data_source).HasColumnName("link_data_source");

            entity.HasIndex(e => e.Link_data_source);

            entity.Property(e => e.Filename)
                .HasColumnName("filename")
                .IsRequired();

            entity.Property(e => e.Link_list_file_format).HasColumnName("link_list_file_format");

            entity.HasIndex(e => e.Link_list_file_format);

            entity.Property(e => e.File_data).HasColumnName("file_data");

            entity.Property(e => e.Uploaded_by).HasColumnName("uploaded_by");

            entity.Property(e => e.Upload_at).HasColumnName("upload_at");

            entity.Property(e => e.Owner_user_id).HasColumnName("owner_user_id");

            entity.HasIndex(e => e.Owner_user_id);
        }
    }
}