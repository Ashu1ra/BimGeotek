using DataAccessService.Domain.Entities.Audit;
using DataAccessService.Domain.Entities.Auth;
using DataAccessService.Domain.Entities.Geo;
using DataAccessService.Domain.Entities.Igt;
using DataAccessService.Domain.Entities.Import;
using DataAccessService.Domain.Entities.Ref;
using DataAccessService.Domain.Entities.Test;

using DataAccessService.InfrastructurePostgres.Persistence.Configurations.AuditConfigurations;
using DataAccessService.InfrastructurePostgres.Persistence.Configurations.AuthConfigurations;
using DataAccessService.InfrastructurePostgres.Persistence.Configurations.GeoConfigurations;
using DataAccessService.InfrastructurePostgres.Persistence.Configurations.IgtConfigurations;
using DataAccessService.InfrastructurePostgres.Persistence.Configurations.ImportConfigurations;
using DataAccessService.InfrastructurePostgres.Persistence.Configurations.RefConfigurations;
using DataAccessService.InfrastructurePostgres.Persistence.Configurations.TestConfigurations;

using Microsoft.EntityFrameworkCore;

namespace DataAccessService.InfrastructurePostgres.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(
            DbContextOptions<AppDbContext> options) : base(options){}

        // ref.*
        public DbSet<List_source_type> SourceTypes => Set<List_source_type>();
        public DbSet<List_file_format> FileFormats => Set<List_file_format>();
        public DbSet<List_region> Regions => Set<List_region>();
        public DbSet<List_borehole_type> BoreholeTypes => Set<List_borehole_type>();
        public DbSet<List_borehole_standard> BoreholeStandards => Set<List_borehole_standard>();
        public DbSet<List_borehole_interval_type> BoreholeIntervalTypes => Set<List_borehole_interval_type>();
        public DbSet<List_sample_standard> SampleStandards => Set<List_sample_standard>();
        public DbSet<List_test_type> TestTypes => Set<List_test_type>();

        // import.*
        public DbSet<Data_source> DataSources => Set<Data_source>();
        public DbSet<Raw_file> RawFiles => Set<Raw_file>();
        public DbSet<Raw_file_entity_link> RawFileEntityLinks => Set<Raw_file_entity_link>();

        // geo.*
        public DbSet<Project> Projects => Set<Project>();
        public DbSet<Site> Sites => Set<Site>();
        public DbSet<Topography> Topographies => Set<Topography>();
        public DbSet<Bim_model> BimModels => Set<Bim_model>();
        public DbSet<City_model> CityModels => Set<City_model>();

        // igt.*
        public DbSet<Borehole> Boreholes => Set<Borehole>();
        public DbSet<Borehole_interval> BoreholeIntervals => Set<Borehole_interval>();
        public DbSet<Sample> Samples => Set<Sample>();

        // test.*
        public DbSet<Field_test> FieldTests => Set<Field_test>();
        public DbSet<Lab_test> LabTests => Set<Lab_test>();

        // auth.*
        public DbSet<User_account> Users => Set<User_account>();
        public DbSet<Group_list> Groups => Set<Group_list>();
        public DbSet<User_group> UserGroups => Set<User_group>();
        public DbSet<Role_list> Roles => Set<Role_list>();
        public DbSet<User_role> UserRoles => Set<User_role>();
        public DbSet<Access_control> AccessControls => Set<Access_control>();

        // audit.*
        public DbSet<Log_borehole> LogBoreholes => Set<Log_borehole>();
        public DbSet<Log_borehole_interval> LogBoreholeIntervals => Set<Log_borehole_interval>();
        public DbSet<Log_sample> LogSamples => Set<Log_sample>();
        public DbSet<Log_test> LogTests => Set<Log_test>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "Host=localhost;Port=5438;Database=geotek_db;Username=admin;Password=admin",
                o => o.UseNetTopologySuite()
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ref.*
            modelBuilder.ApplyConfiguration(new ListSourceTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ListFileFormatConfiguration());
            modelBuilder.ApplyConfiguration(new ListRegionConfiguration());
            modelBuilder.ApplyConfiguration(new ListBoreholeTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ListBoreholeStandardConfiguration());
            modelBuilder.ApplyConfiguration(new ListBoreholeIntervalTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ListSampleStandardConfiguration());
            modelBuilder.ApplyConfiguration(new ListTestTypeConfiguration());

            // import.*
            modelBuilder.ApplyConfiguration(new DataSourceConfiguration());
            modelBuilder.ApplyConfiguration(new RawFileConfiguration());
            modelBuilder.ApplyConfiguration(new RawFileEntityLinkConfiguration());

            // geo.*
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new SiteConfiguration());
            modelBuilder.ApplyConfiguration(new TopographyConfiguration());
            modelBuilder.ApplyConfiguration(new BimModelConfiguration());
            modelBuilder.ApplyConfiguration(new CityModelConfiguration());

            // igt.*
            modelBuilder.ApplyConfiguration(new BoreholeConfiguration());
            modelBuilder.ApplyConfiguration(new BoreholeIntervalConfiguration());
            modelBuilder.ApplyConfiguration(new SampleConfiguration());

            // test.*
            modelBuilder.ApplyConfiguration(new FieldTestConfiguration());
            modelBuilder.ApplyConfiguration(new LabTestConfiguration());

            // auth.*
            modelBuilder.ApplyConfiguration(new UserAccountConfiguration());
            modelBuilder.ApplyConfiguration(new GroupListConfiguration());
            modelBuilder.ApplyConfiguration(new UserGroupConfiguration());
            modelBuilder.ApplyConfiguration(new RoleListConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new AccessControlConfiguration());

            // audit.*
            modelBuilder.ApplyConfiguration(new LogBoreholeConfiguration());
            modelBuilder.ApplyConfiguration(new LogBoreholeIntervalConfiguration());
            modelBuilder.ApplyConfiguration(new LogSampleConfiguration());
            modelBuilder.ApplyConfiguration(new LogTestConfiguration());
        }
    }
}