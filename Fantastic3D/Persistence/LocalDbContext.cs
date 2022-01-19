using Fantastic3D.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;	
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Fantastic3D.Persistence
{
    public class LocalDbContext : DbContext
    {
        public LocalDbContext(DbContextOptions<LocalDbContext> options) : base(options)
        {
            //DbSetForType = new Dictionary<Type, string>
            //{
            //    { typeof(UserEntity), nameof(Users) },
            //    { typeof(AssetEntity), nameof(Assets) },
            //    { typeof(OrderEntity), nameof(Orders) },
            //    { typeof(PurchaseEntity), nameof(Purchases) },
            //    { typeof(ReviewEntity), nameof(Reviews) },
            //    { typeof(TagEntity), nameof(Tags) },
            //    { typeof(TagTypeEntity), nameof(TagTypes) },
            //};
        }
        //public DbSet<UserEntity> Users { get; set; }
        //public DbSet<AssetEntity> Assets { get; set; }
        //public DbSet<OrderEntity> Orders { get; set; }
        //public DbSet<PurchaseEntity> Purchases { get; set; }
        //public DbSet<ReviewEntity> Reviews { get; set; }
        //public DbSet<TagEntity> Tags { get; set; }
        //public DbSet<TagTypeEntity> TagTypes { get; set; }
        //public Dictionary<Type, string> DbSetForType { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // Le code ci-dessous évite que la suppression en cascade par foreign key.
                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
            }
            base.OnModelCreating(modelBuilder);
        }

    }
}
