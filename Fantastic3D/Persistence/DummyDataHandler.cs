using Fantastic3D.Models;

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
                case List<TagType> tagTypeList:
                    tagTypeList.AddRange(new List<TagType>()
                    {
                        new TagType("Thématique", true, false),
                        new TagType("Catégories", true, false),
                        new TagType("Style", false, false),
                        new TagType("Format", false, isOnlyOne:true),
                        new TagType("Licence", false, isOnlyOne:true),
                        new TagType("Capacités", false, false),
                    });
                    break;
                case List<Asset> assetsList:
                    var tagList = new List<Tag>();
                    var fakeUser = new User(Guid.NewGuid(), "fakeuser", "Fake", "User", "fake.user@dontmind.me", "foobar", "1 avenue de la Data, Dropville", UserRole.Premium);
                    assetsList.AddRange(new List<Asset>()
                    {
                        new Asset("Puffin lowPoly", "A low-poly puffin. How convenient!", 0f, "puffin.fbx", "atlantic-puffin-2.jpg", tagList, fakeUser),
                        new Asset("Haunted castle", "A haunted castle. How scary!", 0f, "castle.3ds", "castle.jpg", tagList, fakeUser),
                        new Asset("Saxophone", "A musical instrument called saxophone. How jazzy!", 0f, "sax.fbx", "sax.jpg", tagList, fakeUser),

                    });;
                    break;
                default:
                    throw new DataTypeNotSupportedException("No dummy data for this Type of Data.");
            }
        }

        public void SaveData(List<T> listToSave)
        {
            throw new SaveNotSupportedException("Dummy Data Handler doesn't support saving.");
        }
    }
}
