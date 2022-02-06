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
        internal IDataManager<TagDto, TagEntity> _tagsData;
        public AssetController(IDataManager<AssetDto, AssetEntity> dataManager, IDataManager<TagDto, TagEntity> tagsManager) : base(dataManager)
        {
            _tagsData = tagsManager;
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
        public IActionResult GetTags(int id)
        {

            try
            {
                var retrievedData = _data.GetAsync(id).Result.Tags;
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
        public IActionResult PostTag(int id, [FromBody] int tagId)
        {
            try
            {
                var assetToUpdate = _data.GetAsync(id).Result;
                if(_tagsData.GetAsync(tagId) == null)
                {
                    return BadRequest("There is not tag with the id: "+ tagId);
                }
                if (!assetToUpdate.Tags.Contains(tagId))
                {
                    assetToUpdate.Tags.Add(tagId);
                }

                _data.UpdateAsync(assetToUpdate.Id, assetToUpdate);
                return AcceptedAtRoute(Request.Query.ToString(), assetToUpdate);
            }
            catch (InvalidOperationException ioe)
            {
                return BadRequest(ioe.Message);
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
        public IActionResult DeleteTag(int id, int tagId)
        {
            try
            {
                var assetToUpdate = _data.GetAsync(id).Result;
                if (!assetToUpdate.Tags.Contains(tagId))
                {
                    assetToUpdate.Tags.Remove(tagId);
                    _data.UpdateAsync(assetToUpdate.Id, assetToUpdate);
                    return AcceptedAtRoute(Request.Query.ToString(), assetToUpdate); // return NoContent(); ?
                }
                return NotFound(id);

            }
            catch (InvalidOperationException ioe)
            {
                return BadRequest(ioe.Message);
            }
        }
    }
}
