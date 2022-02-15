namespace Fantastic3D.DataManager
{

    public interface INestedDataManager<TTransferedTag>
    {
        public Task<IEnumerable<TTransferedTag>> GetTagsAsync(int transferedAssetId);
        public Task<bool> AddTagAsync(int transferedAssetId, int transferedTagId);
        public Task<bool> RemoveTagAsync(int transferedAssetId, int transferedTagId);
    }
}