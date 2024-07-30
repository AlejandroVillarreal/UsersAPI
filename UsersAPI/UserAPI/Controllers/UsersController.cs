using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Core.Domain.Entities;
using UserAPI.Core.ServiceContracts;
using UserAPI.Core.Services;
using UserAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUserGetAllService _UserGetAllService;
		private readonly IUserGetByIdService _UserGetByIdService;
		private readonly IUserAddService _UserAddService;
		private readonly IUserUpdateService _UserUpdateService;
		private readonly IUserDeleteService _UserDeleteService;

		public UsersController(IUserGetAllService UserGetAllService,
			IUserGetByIdService UserGetByIdService,
			IUserAddService UserAddService,
			IUserUpdateService UserUpdateService,
			IUserDeleteService UserDeleteService)
		{
			_UserGetAllService = UserGetAllService;
			_UserGetByIdService = UserGetByIdService;
			_UserAddService = UserAddService;
			_UserUpdateService = UserUpdateService;
			_UserDeleteService = UserDeleteService;
		}
		// GET: api/<UsersController>
		[HttpGet]
		public async Task<ActionResult<IEnumerable<User>>> GetUsers()
		{
			IEnumerable<UserEntity> Users = await _UserGetAllService.GetAllUsersAsync();
			List<User> UserList = Users.Select(r => new User
			{
				Id = r.Id,
				Name = r.Name,
				Species = r.Species,
				Age = r.Age,
				Habitat = r.Habitat,
				Weight = r.Weight,
				Description = r.Description,
				DateOfBirth = r.DateOfBirth
			}).ToList();

			return Ok(UserList);
		}

		// GET api/<UsersController>/5
		[HttpGet("{id}")]
		public async Task<ActionResult<User>> GetUserById(Guid id)
		{
			var UserById = await _UserGetByIdService.GetByIdAsync(id);
			var UserModel = new User
			{
				Name = UserById.Name,
				Species = UserById.Species,
				Age = UserById.Age,
				Habitat = UserById.Habitat,
				Weight = UserById.Weight,
				Description = UserById.Description,
				DateOfBirth = UserById.DateOfBirth
			};
			return Ok(UserModel);
		}

		// POST api/<UsersController>
		[HttpPost]
		public async Task<ActionResult<IEnumerable<User>>> AddUser([FromBody] User User)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var newUser = new UserEntity
			{
				Name = User.Name,
				Species = User.Species,
				Age = User.Age,
				Habitat = User.Habitat,
				Weight = User.Weight,
				Description = User.Description,
				DateOfBirth = User.DateOfBirth
			};
			
			await _UserAddService.AddAsync(newUser);

			return CreatedAtAction(nameof(GetUserById), new { id = User.Id }, User);
		}

		// PUT api/<UsersController>/5
		[HttpPut("{id}")]
		public async Task<ActionResult<bool>> EditUser(Guid id,[FromBody] User User)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var editUser = new UserEntity
			{
				
				Name = User.Name,
				Species = User.Species,
				Age = User.Age,
				Habitat = User.Habitat,
				Weight = User.Weight,
				Description = User.Description,
				DateOfBirth = User.DateOfBirth
			};

			await _UserUpdateService.UpdateUserAsync(id, editUser);
			return Ok();
		}

		// DELETE api/<UsersController>/5
		[HttpDelete("{id}")]
		public async Task<ActionResult<bool>> DeleteUser(Guid id)
		{
			await _UserDeleteService.DeleteAsync(id);
			return Ok(true);
		}
	}
}
