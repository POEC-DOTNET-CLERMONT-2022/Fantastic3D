using Fantastic3D.DataManager;
using Fantastic3D.Dto;
using Fantastic3D.Persistence.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Fantastic3D.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : GenericController<AssetDto, AssetEntity>
    {
        internal INestedDataManager<TagDto> _tagsData;
        public AssetController(IDataManager<AssetDto, AssetEntity> dataManager, INestedDataManager<TagDto> nestedDataManager) : base(dataManager)
        {
            _tagsData = nestedDataManager;
        }
        // GET api/Asset/5/Tag/
        /// <summary>
        /// Retrieves all tags from a given asset
        /// </summary>
        /// <param name="id" example="5">The element ID.</param>
        [HttpGet("{id}/Tag")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTags(int id)
        {
            try
            {
                var retrievedData = await _tagsData.GetTagsAsync(id);
                if (retrievedData == null)
                    return NotFound(id);
                return Ok(retrievedData);
            }
            catch (InvalidOperationException ioe)
            {
                return BadRequest(ioe.Message);
            }
        }
        // POST api/Asset/5/Tag/
        /// <summary>
        /// Adds a tag to a given asset.
        /// </summary>
        /// <param name="id" example="5">The element ID.</param>
        /// <param name="tagId" example="8">The tag ID.</param>
        [HttpPost("{id}/Tag")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostTag(int id, [FromBody] int tagId)
        {
            try
            {
                var addSuccess = await _tagsData.AddTagAsync(id, tagId);
                return addSuccess ? Ok($"Tag {tagId} added to asset {id}.") : BadRequest("No rows were affected.");
            }
            catch (DataRecordException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // DELETE api/Asset/5/Tag/8
        /// <summary>
        /// Removes a tag from a given asset.
        /// </summary>
        /// <param name="id" example="5">The element ID.</param>
        /// <param name="tagId" example="8">The tag ID.</param>
        [HttpDelete("{id}/Tag/{tagId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteTag(int id, int tagId)
        {
            try
            {
                var removeSuccess = await _tagsData.RemoveTagAsync(id, tagId);
                if (removeSuccess)
                    return Ok($"Tag {tagId} removed from asset {id}.");
                return BadRequest("Tag add action did not happen.");
            }
            catch (DataRecordException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
