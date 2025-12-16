using App.Core.Entities;
using App.Core.Entities.Commons;
using App.Core.Entities.Identity;
using App.Core.Entities.Orders;
using App.Core.Entities.Payments;
using App.Core.Entities.Relations;
using App.Shared.Services.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;

namespace App.DAL.Presistence
{
	public class AppDbContext : IdentityDbContext<User>
    {
        private readonly IClaimService? _claimService;

        public AppDbContext(DbContextOptions<AppDbContext> options, 
            IClaimService? claimService = null) : base(options)
        {
            _claimService = claimService;
        }

        // Models Here !!
        public DbSet<Product> Products => Set<Product>();
        public DbSet<ProductDetail> ProductDetails => Set<ProductDetail>();
        public DbSet<ProductField> ProductFields => Set<ProductField>();
        public DbSet<Slide> Slides => Set<Slide>();
        public DbSet<Setting> Settings => Set<Setting>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<SubCategory> SubCategories => Set<SubCategory>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();
        public DbSet<Invoice> Invoices => Set<Invoice>();



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public new async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            var userId = _claimService?.GetUserId() ?? "ByServer";

            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedById = userId;
                        entry.Entity.CreatedOn = DateTime.UtcNow;

                        entry.Entity.LastModifiedById = userId;
                        entry.Entity.LastModifiedOn = DateTime.UtcNow;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedById = userId;
                        entry.Entity.LastModifiedOn = DateTime.UtcNow;
                        break;

                    case EntityState.Deleted:
                        entry.Entity.DeletedById = userId;
                        entry.Entity.DeletedOn = DateTime.UtcNow;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
