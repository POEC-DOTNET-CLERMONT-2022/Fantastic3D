using Fantastic3D.Persistence.Entities;
using AutoFixture;

namespace Fantastic3D.Persistence
{
    /// <summary>
    /// Dummy Data generation for quick testing. Should not be used in the final project.
    /// </summary>
    public class DummyDataHandler<T> : IDataHandler<T> where T : IPersistable
    {

        public void LoadData(List<T> loadedList)
        {
            switch (loadedList)
            {
                case List<TagTypeEntity> tagTypeList:
                    tagTypeList.AddRange(new List<TagTypeEntity>()
                    {
                        new TagTypeEntity("Thématique", true, false),
                        new TagTypeEntity("Catégories", true, false),
                        new TagTypeEntity("Style", false, false),
                        new TagTypeEntity("Format", false, isOnlyOne:true),
                        new TagTypeEntity("Licence", false, isOnlyOne:true),
                        new TagTypeEntity("Capacités", false, false),
                    });
                    break;
                case List<TagEntity> tagList:
                    tagList.AddRange(new List<TagEntity>()
                    {
                        new TagEntity("Horreur", 1),
                        new TagEntity("Moderne", 1),
                        new TagEntity("fbx", 4),
                        new TagEntity("obj", 4),
                        new TagEntity("Usage personnel", 5),
                        new TagEntity("Usage commercial", 5),
                        new TagEntity("Libre de droits", 5),
                        new TagEntity("Texture", 6),
                        new TagEntity("Rigging", 6),
                        new TagEntity("Animation", 6),
                    });
                    break;
                case List<AssetEntity> assetsList:
                    //var tagList = new List<TagEntity>();
                    //var fakeUser = new UserEntity(1, "fakeuser", "Fake", "User", "fake.user@dontmind.me", "foobar", "1 avenue de la Data, Dropville", UserRole.Premium);
                    assetsList.AddRange(new List<AssetEntity>()
                    {
                        new AssetEntity("Puffin lowPoly", "A low-poly puffin. How convenient!", 0f, "puffin.fbx", "atlantic-puffin-2.jpg", 1),
                        new AssetEntity("Haunted castle", "A haunted castle. How scary!", 0f, "castle.3ds", "castle.jpg", 1),
                        new AssetEntity("Saxophone", "A musical instrument called saxophone. How jazzy!", 0f, "sax.fbx", "sax.jpg", 1),

                    });
                    break;
                case List<UserEntity> userList:
                    userList.AddRange(new List<UserEntity>()
                    {
                        new UserEntity("Alain", "Alain", "Terieur", "aterr@hotmail.com", "1234", "110 avenue des près", UserRole.Admin),
                        new UserEntity("DaFlash", "Barry", "Badlen", "bbadlen@csi.ccpd.gov", "1234", "1 avenue des bolides", UserRole.Premium),
                        new UserEntity("Kiki", "Carl", "Ikki", "carliki@hotmail.com", "1234", "3 chemin du Kernel", UserRole.Basic),

                    });
                    break;
                default:
                    var fixture = new Fixture();
                    var createdList = fixture.CreateMany<T>(15).ToList();
                    loadedList.AddRange(createdList);
                    break;
                    //throw new DataTypeNotSupportedException("No dummy data for this Type of Data.");
            }
        }

        public void SaveData(List<T> listToSave)
        {
            throw new SaveNotSupportedException("Dummy Data Handler doesn't support saving.");
        }
    }
}
