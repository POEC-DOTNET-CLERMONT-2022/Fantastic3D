using Microsoft.AspNetCore.Mvc;
using Fantastic3D.Dto;
using Fantastic3D.DataManager;
using Fantastic3D.Persistence.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fantastic3D.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<TOut, TIn> : ControllerBase
       where TOut : IManageable, new()
       where TIn : IManageable, new()
    {
        internal IDataManager<TOut, TIn> _data;

        public GenericController(IDataManager<TOut, TIn> dataManager)
        {
            _data = dataManager;
        }

        // GET: api/<GenericController>
        /// <summary>
        /// Retrieves all the users.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get()
        {
            var data = await _data.GetAllAsync();
            return (data.Any()) ? Ok(data) : NoContent();
        }

        // GET api/<GenericController>/5
        /// <summary>
        /// Retrieves the informations of a database content
        /// </summary>
        /// <param name="id" example="5">The element ID.</param>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var retrievedData = await _data.GetAsync(id);
                if (retrievedData == null)
                    return NotFound(id);
                return Ok(retrievedData);
            }
            catch (DataRetrieveException dre)
            {
                return NotFound(dre.Message);
            }
            catch (InvalidOperationException ioe)
            {
                return BadRequest(ioe.Message);
            }
        }

        // POST api/<GenericController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] TOut newValue)
        {
            try
            {
                await _data.AddAsync(newValue);
                return Created(Request.Query.ToString(), newValue);
            }
            catch (DataRecordException dre)
            {
                return BadRequest(dre);
            }
        }

        // PUT api/<GenericController>/5
        /// <summary>
        /// Changes the informations of an user.
        /// </summary>
        /// <param name="id" example="5">The user's ID.</param>
        /// <param name="value">Full description of an user</param>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(int id, [FromBody] TOut updatedValue)
        {
            try
            {
                await _data.UpdateAsync(id, updatedValue);
                return base.Created(Request.Query.ToString(), updatedValue);
            }
            catch (DataRecordException dre)
            {
                return BadRequest(updatedValue.ToString() + dre.ToString());
            }
        }

        // DELETE api/<GenericController>/5
        // GET api/<GenericController>/5
        /// <summary>
        /// Deletes a value by its id.
        /// </summary>
        /// <param name="id" example="5">The user's ID.</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _data.DeleteAsync(id);
                return NoContent();
            }
            catch (DataRecordException dre)
            {
                return NotFound(dre.Message);
            }
        }
    }
}
