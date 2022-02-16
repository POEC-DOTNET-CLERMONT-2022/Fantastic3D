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
    public class DbNestedDataManager<TTransferedTag> : INestedDataManager<TTransferedTag>
        where TTransferedTag : TagDto, new()
    {
        private readonly IDbContextFactory<LocalDbContext> _contextFactory;
        private readonly IMapper _mapper;

        public DbNestedDataManager(IDbContextFactory<LocalDbContext> contextFactory, IMapper mapper)
        {
            _contextFactory = contextFactory;
            _mapper = mapper;
        }

        public async Task<bool> AddTagAsync(int transferedAssetId, int transferedTagId)
        {
            using LocalDbContext context = _contextFactory.CreateDbContext();
            try
            {
                var tagToAdd = await context.Tags.SingleAsync(tag => tag.Id == transferedTagId);
                var assetToUpdate = await context.Assets.SingleAsync(asset => asset.Id == transferedAssetId);
                if (assetToUpdate.Tags == null)
                    assetToUpdate.Tags = new List<TagEntity>();
                assetToUpdate.Tags.Add(tagToAdd);
                context.Assets.Update(assetToUpdate);
                var writtenEntries = await context.SaveChangesAsync();
                return (writtenEntries == 2);
            }
            catch (InvalidOperationException ioe)
            {
                return false;
                throw new DataRecordException("Tag or Asset was not found. ", ioe);
            }
            catch (ArgumentNullException ane)
            {
                return false;
                throw new DataRecordException("Id or DataSource is null. ", ane);
            }
            catch (Exception ex)
            {
                return false;
                throw new DataRecordException("Exception encoutered: ", ex);
            }
        }

        public async Task<bool> RemoveTagAsync(int transferedAssetId, int transferedTagId)
        {
            using LocalDbContext context = _contextFactory.CreateDbContext();
            try
            {
                var tagToRemove = await context.Tags.SingleAsync(tag => tag.Id == transferedTagId);
                var assetToUpdate = await context.Assets.SingleAsync(asset => asset.Id == transferedAssetId);

                if (assetToUpdate.Tags != null)
                {
                    assetToUpdate.Tags.Remove(tagToRemove);
                    context.Assets.Update(assetToUpdate);
                    await context.SaveChangesAsync();
                }
            }
            catch (InvalidOperationException ioe)
            {
                return false;
                throw new DataRecordException("Tag or asset was not found. ", ioe);
            }
            catch (ArgumentNullException ane)
            {
                return false;
                throw new DataRecordException("Id or DataSource is null. ", ane);
            }
            catch (Exception ex)
            {
                return false;
                throw new DataRecordException("Unexpected error when deleting data: ", ex);
            }
            return true;
        }

        public async Task<IEnumerable<TTransferedTag>> GetTagsAsync(int transferedAssetId)
        {
            using LocalDbContext context = _contextFactory.CreateDbContext();
            try
            {
                var assetToRead = await context.Assets.SingleAsync(asset => asset.Id == transferedAssetId);
                var tags = assetToRead.Tags;
                if(tags == null)
                    return Enumerable.Empty<TTransferedTag>();
                return _mapper.Map<IEnumerable<TTransferedTag>>(tags);
            }
            catch (InvalidOperationException ioe)
            {
                throw new DataRetrieveException("Asset was not found. ", ioe);
            }
            catch (ArgumentNullException ane)
            {
                throw new DataRetrieveException("Id or DataSource is null. ", ane);
            }
            catch (Exception ex)
            {
                throw new DataRetrieveException("Unexpected Exception while reading data: ", ex);
            }
        }
    }
}
