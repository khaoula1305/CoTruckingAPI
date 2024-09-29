using Cotrucking.Infrastructure.Entities;
using Cotrucking.Infrastructure.Entities.Security;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cotrucking.Infrastructure
{
    public class CotruckingDbContext : IdentityDbContext<UserDataModel,RoleDataModel, Guid>
    {
        public CotruckingDbContext(DbContextOptions<CotruckingDbContext> options) : base(options)
        {
        }

        public DbSet<PageFunctionalityDataModel> PageFunctionalities { get; set; }
        public DbSet<PageDataModel> Pages { get; set; }
        public DbSet<FunctionalityDataModel> Functionalities { get; set; }
        public DbSet<CompanyDataModel> Companies { get; set; }
        public DbSet<DriverDataModel> Drivers { get; set; }
        public DbSet<AddressDataModel> Addresses { get; set; }
        public DbSet<CountryDataModel> Countries { get; set; }
        public DbSet<CityDataModel> Cities { get; set; }
        public DbSet<VehiculeDataModel> Vehicles { get; set; }
        public DbSet<ShipmentDataModel> Shipments { get; set; }
        public DbSet<AssignmentDataModel> Assignments { get; set; }
        public DbSet<RequestDataModel> Requests { get; set; }
        public DbSet<ApplicationDataModel> Applications { get; set; }
        public DbSet<RefreshTokenDataModel> RefreshTokens { get; set; }
        public DbSet<EmployeeDataModel> Employees { get; set; }
        public DbSet<RentalDataModel> Rentals { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserDataModel>()
                .HasOne(x => x.Role)
                .WithMany(y => y.Users)
                .HasForeignKey(y => y.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserDataModel>()
                .HasOne(x => x.Driver)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.SetNull);


            modelBuilder.Entity<DriverDataModel>()
                .HasOne(x => x.User)
                .WithOne(y => y.Driver)
                .HasForeignKey<DriverDataModel>(y => y.UserId)
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
