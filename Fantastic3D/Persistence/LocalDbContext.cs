using Fantastic3D.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fantastic3D.Persistence
{
    public class LocalDbContext : DbContext
    {
        public LocalDbContext(DbContextOptions<LocalDbContext> options) : base(options)
        {

        }

        public DbSet<AssetEntity> Assets { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<PurchaseEntity> Purchases { get; set; }
        public DbSet<ReviewEntity> Reviews { get; set; }
        public DbSet<TagEntity> Tags { get; set; }
        public DbSet<TagTypeEntity> TagTypes { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var userBuilder = modelBuilder.Entity<UserEntity>();
            base.OnModelCreating(modelBuilder);
        }

    }
}
