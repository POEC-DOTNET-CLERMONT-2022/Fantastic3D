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
