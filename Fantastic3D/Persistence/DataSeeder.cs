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
                var userList = new List<UserEntity>()
                {
                    new UserEntity("Alain", "Alain", "Terieur", "aterr@hotmail.com", "1234", "110 avenue des près", UserRole.Admin),
                    new UserEntity("DaFlash", "Barry", "Badlen", "bbadlen@csi.ccpd.gov", "1234", "1 avenue des bolides", UserRole.Premium),
                    new UserEntity("Kiki", "Carl", "Ikki", "carliki@hotmail.com", "1234", "3 chemin du Kernel", UserRole.Basic),
                };
                context.AddRange(userList);
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
            // TODO : Ajouter manuellement un jeu de données Plausible pour les types suivnats
            // (Fixture ne gère pas les dépendances fortes des ID)
            //if (!context.Set<OrderEntity>().Any())
            //{
            //    context.AddRange(GetDummyData<OrderEntity>());
            //}
            //if (!context.Set<PurchaseEntity>().Any())
            //{
            //    context.AddRange(GetDummyData<PurchaseEntity>());
            //}
            //if (!context.Set<ReviewEntity>().Any())
            //{
            //    context.AddRange(GetDummyData<ReviewEntity>());
            //}
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
