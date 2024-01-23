using Cotrucking.Domain.Entities;
using Cotrucking.Domain.Entities.Security;
using Microsoft.EntityFrameworkCore;

namespace Cotrucking.Infrastructure
{
    public class CotruckingDbContext : DbContext
    {
        public CotruckingDbContext(DbContextOptions<CotruckingDbContext> options) : base(options)
        {
        }

        public DbSet<PageFunctionalityDataModel> PageFunctionalities { get; set; }
        public DbSet<UserDataModel> Users { get; set; }
        public DbSet<RoleDataModel> Roles { get; set; }
        public DbSet<PageDataModel> Pages { get; set; }
        public DbSet<FunctionalityDataModel> Functionalities { get; set; }
        public DbSet<CompanyDataModel> Companies { get; set; }
        public DbSet<TransporterDataModel> Transporters { get; set; }
        public DbSet<AddressDataModel> Addresses { get; set; }
        public DbSet<CountryDataModel> Countries { get; set; }
        public DbSet<CityDataModel> Cities { get; set; }
        public DbSet<VehicleDataModel> Vehicles { get; set; }
        public DbSet<ShipmentDataModel> Shipments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDataModel>()
                .HasOne(x => x.Role)
                .WithMany(y => y.Users)
                .HasForeignKey(y => y.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserDataModel>()
                .HasOne(x => x.Transporter)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<TransporterDataModel>()
                .HasOne(x => x.User)
                .WithOne(y => y.Transporter)
                .HasForeignKey<TransporterDataModel>(y => y.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CustomerDataModel>()
                .HasOne(x => x.User)
                .WithOne(y => y.Customer)
                .HasForeignKey<CustomerDataModel>(y => y.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CompanyDataModel>()
                .HasOne(x => x.Address)
                .WithMany()
                .HasForeignKey(y => y.AddressId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
