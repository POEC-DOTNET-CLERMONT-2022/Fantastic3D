using Fantastic3D.Models;
using Fantastic3D.Persistence;

namespace Fantastic3D.Tags
{
    /// <summary>
    /// Operations of Add, Delete, Update, and list for the application tags.
    /// </summary>
    internal class TagManager
    {
        private IDataHandler<Tag> _dataHandler;
        private List<Tag> _listTag = new List<Tag>();
        private List<TagType> _tagTypes;

        public TagManager( IDataHandler<Tag> dataHandler, List<TagType> tagTypes)
        {
            _dataHandler = dataHandler;
            _tagTypes = tagTypes;
        }

        public List<Tag> listTag
        { get { return _listTag; } }    
  

        /// <summary>
        /// Load Tag list if exist
        /// </summary>
        public void LoadList()
        {
            if(_listTag.Count == 0)
            {
                try
                {
                    _dataHandler.LoadData(_listTag);
                }
                catch (Exception ex)
                {
                    // TODO Faire le catch de 
                }
            }
        }


        /// <summary>
        /// Add tag with his type
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="tagType"></param>
        public void Add(string Name, TagType tagType)
        {
            var mytag = new Tag(Name, tagType);
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
