using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Fantastic3D.DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fantastic3D.Dto;
using Fantastic3D.Persistence.Entities;

namespace Fantastic3D.Persistence
{
    public class DbNestedDataManager<TTransferedTag, TPersistantAsset, TPersistantTag>
        : INestedDataManager<TTransferedTag, TPersistantAsset, TPersistantTag>
        where TTransferedTag : TagDto, new()
        where TPersistantAsset : AssetEntity, new()
        where TPersistantTag : TagEntity, new()
    {
        LocalDbContext _context;
        private IMapper _mapper;
        private DbSet<TPersistantAsset> _assetDataSet;
        private DbSet<TPersistantTag> _tagsDataSet;

        public DbNestedDataManager(LocalDbContext context, IMapper mapper)
        {
            _context = context;
            _assetDataSet = context.Set<TPersistantAsset>();
            _tagsDataSet = context.Set<TPersistantTag>();
            _mapper = mapper;
        }

        public async Task<bool> AddTagAsync(int transferedAssetId, int transferedTagId)
        {
            try
            { 
                var tagToAdd = await _tagsDataSet.SingleAsync(tag => tag.Id == transferedTagId);
                var assetToUpdate = await _assetDataSet.SingleAsync(asset => asset.Id == transferedAssetId);
                if(assetToUpdate.Tags == null)
                    assetToUpdate.Tags = new List<TagEntity>();
                assetToUpdate.Tags.Add(tagToAdd);
                await _context.SaveChangesAsync();
            }
            catch (InvalidOperationException ioe)
            {
                return false;
                throw new InvalidOperationException("Tag or Asset was not found. ", ioe);
            }
            catch (ArgumentNullException ane)
            {
                return false;
                throw new ArgumentNullException("Id or DataSource is null. ", ane);
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception("Exception encoutered: ", ex);
            }
            return true;
        }

        public async Task<bool> RemoveTagAsync(int transferedAssetId, int transferedTagId)
        {
            try
            {
                var tagToRemove = await _tagsDataSet.SingleAsync(tag => tag.Id == transferedTagId);
                var assetToUpdate = await _assetDataSet.SingleAsync(asset => asset.Id == transferedAssetId);

                if (assetToUpdate.Tags != null)
                {
                    assetToUpdate.Tags.Remove(tagToRemove);
                    await _context.SaveChangesAsync();
                }
            }
            catch (InvalidOperationException ioe)
            {
                return false;
                throw new InvalidOperationException("Tag or asset was not found. ", ioe);
            }
            catch (ArgumentNullException ane)
            {
                return false;
                throw new InvalidOperationException("Id or DataSource is null. ", ane);
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception("Unexpected Exception: ", ex);
            }
            return true;
        }

        public async Task<IEnumerable<TTransferedTag>> GetTagsAsync(int transferedAssetId)
        {
            try
            {
                var assetToRead = await _assetDataSet.SingleAsync(asset => asset.Id == transferedAssetId);
                var tags = assetToRead.Tags;
                if(tags == null)
                    return Enumerable.Empty<TTransferedTag>();
                //return tags.Select(tag => _mapper.Map<TTransferedTag>(tag));
                return _mapper.Map<IEnumerable<TTransferedTag>>(tags);
            }
            catch (InvalidOperationException ioe)
            {
                throw new InvalidOperationException("Asset was not found. ", ioe);
            }
            catch (ArgumentNullException ane)
            {
                throw new InvalidOperationException("Id or DataSource is null. ", ane);
            }
            catch (Exception ex)
            {
                throw new Exception("Unexpected Exception: ", ex);
            }
        }
    }
}
