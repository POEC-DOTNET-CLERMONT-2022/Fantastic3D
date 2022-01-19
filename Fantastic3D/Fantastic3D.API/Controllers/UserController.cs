using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fantastic3D.Persistence.Entities;
using Fantastic3D.Persistence;
using Fantastic3D.Dto;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fantastic32.UsersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IRepository<UserDto, UserEntity> _repository;

        public UserController(LocalDbContext context, IMapper mapper)
        {
            _repository = new DbRepository<UserDto, UserEntity>(context, mapper);
        }

        // GET: api/<UserController>
        /// <summary>
        /// Retrieves all the users.
        /// </summary>
        [HttpGet]
        public IEnumerable<UserDto> Get()
        {
            return _repository.GetAll();
        }

        // GET api/<UserController>/5
        /// <summary>
        /// Retrieves the informations of an user.
        /// </summary>
        /// <param name="id" example="5">The user's ID.</param>
        [HttpGet("{id}")]
        public UserDto Get(int id)
        {
            return _repository.Get(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] UserDto newUser)
        {
            _repository.Add(newUser);
        }

        // PUT api/<UserController>/5
        /// <summary>
        /// Changes the informations of an user.
        /// </summary>
        /// <param name="id" example="5">The user's ID.</param>
        /// <param name="value">Full description of an user</param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UserDto newUserValues)
        {
            _repository.Update(id, newUserValues);
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
            _repository.Delete(id);
        }
    }
}
