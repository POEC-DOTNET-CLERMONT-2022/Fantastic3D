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
                case List<AssetEntity> assetsList:
                    var tagList = new List<TagEntity>();
                    var fakeUser = new UserEntity(1, "fakeuser", "Fake", "User", "fake.user@dontmind.me", "foobar", "1 avenue de la Data, Dropville", UserRole.Premium);
                    assetsList.AddRange(new List<AssetEntity>()
                    {
                        new AssetEntity("Puffin lowPoly", "A low-poly puffin. How convenient!", 0f, "puffin.fbx", "atlantic-puffin-2.jpg", tagList, fakeUser),
                        new AssetEntity("Haunted castle", "A haunted castle. How scary!", 0f, "castle.3ds", "castle.jpg", tagList, fakeUser),
                        new AssetEntity("Saxophone", "A musical instrument called saxophone. How jazzy!", 0f, "sax.fbx", "sax.jpg", tagList, fakeUser),

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
