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
        public IActionResult Get()
        {
            var data = _data.GetAllAsync().Result;
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
        public IActionResult Get(int id)
        {
            try
            {
                var retrievedData = _data.GetAsync(id).Result;
                if (retrievedData == null)
                    return NotFound(id);
                return Ok(retrievedData);
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
        public IActionResult Post([FromBody] TOut newValue)
        {
            try
            {
                _data.AddAsync(newValue);
                return Created(Request.Query.ToString(), newValue);
            }
            catch (Exception e)
            {
                return BadRequest(newValue);
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
        public IActionResult Put(int id, [FromBody] TOut updatedValue)
        {
            try
            {
                _data.UpdateAsync(id, updatedValue);
                return base.Created(Request.Query.ToString(), _data.GetAsync(id).Result);
            }
            catch (Exception e)
            {
                return BadRequest(updatedValue);
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
        public IActionResult Delete(int id)
        {
            try
            {
                _data.DeleteAsync(id);
                return NoContent();
            }
            catch
            {
                return NotFound(id);
            }
        }
    }
}
