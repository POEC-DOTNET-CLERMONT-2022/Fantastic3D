using Fantastic3D.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fantastic3D.DataManager;

namespace Fantastic3D.Persistence
{
    public class DataSeeder
    {
        public static void PopulateData(LocalDbContext context)
        {
            if (!context.Set<UserEntity>().Any())
            {
                context.AddRange(GetDummyData<UserEntity>());
                context.SaveChanges();
            }
            if (!context.Set<TagTypeEntity>().Any())
            {
                context.AddRange(GetDummyData<TagTypeEntity>());
                context.SaveChanges();
            }
            if (!context.Set<TagEntity>().Any())
            {
                context.AddRange(GetDummyData<TagEntity>());
                context.SaveChanges();
            }
            if (!context.Set<AssetEntity>().Any())
            {
                context.AddRange(GetDummyData<AssetEntity>());
                context.SaveChanges();
            }
            if (!context.Set<OrderEntity>().Any())
            {
                context.AddRange(GetDummyData<OrderEntity>());
                context.SaveChanges();
            }
            if (!context.Set<PurchaseEntity>().Any())
            {
                context.AddRange(GetDummyData<PurchaseEntity>());
                context.SaveChanges();
            }
            if (!context.Set<ReviewEntity>().Any())
            {
                context.AddRange(GetDummyData<ReviewEntity>());
                context.SaveChanges();
            }
            context.SaveChanges();
        }

        static List<T> GetDummyData<T>() where T : IManageable
        {
            var dataSource = new DummyDataHandler<T>();
            var dummyData = new List<T>();
            dataSource.LoadData(dummyData);
            return dummyData;
        }
    }

}
