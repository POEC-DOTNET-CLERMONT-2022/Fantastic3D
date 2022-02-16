using Fantastic3D.Persistence.Entities;
using Fantastic3D.Persistence;

namespace Fantastic3D.Tags
{
    /// <summary>
    /// Operations of Add, Delete, Update, and list for the application tags.
    /// </summary>
    internal class TagManager
    {
        private IDataHandler<TagEntity> _dataHandler;
        private List<TagEntity> _listTag = new List<TagEntity>();

        public TagManager( IDataHandler<TagEntity> dataHandler, List<TagTypeEntity> tagTypes)
        {
            _dataHandler = dataHandler;
            _tagTypes = tagTypes;
        }

        public List<TagEntity> listTag
        { get { return _listTag; } }    
  

        /// <summary>
        /// Load Tag list if exist
        /// </summary>
        public void LoadList()
        {
            if(_listTag.Count == 0)
            {
                _dataHandler.LoadData(_listTag);
            }
        }


        /// <summary>
        /// Add tag with his type
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="tagType"></param>
        public void Add(string Name, TagTypeEntity tagType)
        {
            var mytag = new TagEntity(Name, tagType.Id);
            _listTag.Add(mytag);
            _dataHandler.SaveData(_listTag);
        }


        /// <summary>
        /// Delete Tag by id
        /// </summary>
        /// <param name="tagId"></param>
        public void Delete(int tagId)
        {
            _listTag.RemoveAt(tagId);
        }

        /// <summary>
        /// Edit Tag by id
        /// </summary>
        /// <param name="tagId"></param>
        /// <param name="inputName"></param>
        public void EditName(int tagId,string inputName)
        {
            _listTag[tagId].Rename(inputName);
        }

        /// <summary>
        /// Return the list count
        /// </summary>
        /// <returns></returns>
        public int GetTagListCount()
        {
            return _listTag.Count;
        }
    }
}
