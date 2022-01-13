using Fantastic3D.UsersAPI;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fantastic32.UsersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/<UserController>
        /// <summary>
        /// Retrieves all the users.
        /// </summary>
        [HttpGet]
        public IEnumerable<UserDto> Get()
        {
            return new UserDto[] { new UserDto(), new UserDto() };
        }

        // GET api/<UserController>/5
        /// <summary>
        /// Retrieves the informations of an user.
        /// </summary>
        /// <param name="id" example="5">The user's ID.</param>
        [HttpGet("{id}")]
        public UserDto Get(int id)
        {
            return new UserDto();
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] UserDto value)
        {
        }

        // PUT api/<UserController>/5
        /// <summary>
        /// Changes the informations of an user.
        /// </summary>
        /// <param name="id" example="5">The user's ID.</param>
        /// <param name="value">Full description of an user</param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UserDto value)
        {
        }

        // PATCH api/<UserController>/role/5
        /// <summary>
        /// Allows the change of a single parameter of an user.
        /// </summary>
        /// <param name="id" example="5">The user's ID.</param>
        /// <param name="field" example="lastName">The field to change (firstName, lastName, email or role).</param>
        /// <param name="value" example="Skywalker">The new value for this field.</param>
        [HttpPatch("{id}/{field}")]
        public void Patch(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        // GET api/<UserController>/5
        /// <summary>
        /// Deletes an user by its id.
        /// </summary>
        /// <param name="id" example="5">The user's ID.</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
