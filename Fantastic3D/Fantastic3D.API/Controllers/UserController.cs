using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fantastic3D.Persistence.Entities;
using Fantastic3D.Persistence;
using Fantastic3D.Dto;
using Fantastic3D.DataManager;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fantastic32.UsersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IDataManager<UserDto, UserEntity> _data;

        public UserController(IDataManager<UserDto, UserEntity> dataManager) 
        {
            // Todo : déplacer l'injection de dépendance directement dans le DataManager
            _data = dataManager; // new DbDataManager<UserDto, UserEntity>(context, mapper);
        }

        // GET: api/<UserController>
        /// <summary>
        /// Retrieves all the users.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserDto>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Get()
        {
            return (_data.GetAll().Any()) ? Ok(_data.GetAll()) : NoContent();
        }

        // GET api/<UserController>/5
        /// <summary>
        /// Retrieves the informations of an user.
        /// </summary>
        /// <param name="id" example="5">The user's ID.</param>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get(int id)
        {
            try
            {
                var retrievedData = _data.Get(id);
                if (retrievedData == null)
                    return NotFound(id);
                return Ok(retrievedData);
            }
            catch(InvalidOperationException ioe)
            {
                return BadRequest(ioe.Message);
            }
        }

        // POST api/<UserController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] UserDto newUser)
        {
            try
            {
                _data.Add(newUser);
                return base.Created(Request.Query.ToString() , newUser);
            }
            catch (Exception e)
            {
                return BadRequest(newUser);
            }
        }

        // PUT api/<UserController>/5
        /// <summary>
        /// Changes the informations of an user.
        /// </summary>
        /// <param name="id" example="5">The user's ID.</param>
        /// <param name="value">Full description of an user</param>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put(int id, [FromBody] UserDto newUserValues)
        {
            try
            {
                _data.Update(id, newUserValues);
                return base.Created(Request.Query.ToString(), newUserValues);
            }
            catch (Exception e)
            {
                return BadRequest(newUserValues);
            }
        }

        // DELETE api/<UserController>/5
        // GET api/<UserController>/5
        /// <summary>
        /// Deletes an user by its id.
        /// </summary>
        /// <param name="id" example="5">The user's ID.</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            try
            {
                _data.Delete(id);
                return NoContent();
            }
            catch
            {
                return NotFound(id);
            }
        }
    }
}
