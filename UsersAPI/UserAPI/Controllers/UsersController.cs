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
		private readonly IUserCreateService _UserCreateService;
		private readonly IUserAddPetService _UserAddPetService;
		private readonly IUserLoginService _UserLoginService;

		private readonly IUserGetAllService _UserGetAllService;
		private readonly IUserGetByIdService _UserGetByIdService;
		private readonly IUserAddService _UserAddService;
		
		private readonly IUserUpdateService _UserUpdateService;
		private readonly IUserDeleteService _UserDeleteService;

		public UsersController(IUserGetAllService UserGetAllService,
			IUserGetByIdService UserGetByIdService,
			IUserAddService UserAddService,
			IUserUpdateService UserUpdateService,
			IUserCreateService UserCreateService,
			IUserLoginService UserLoginService,
			IUserDeleteService UserDeleteService)
		{
			_UserGetAllService = UserGetAllService;
			_UserGetByIdService = UserGetByIdService;
			_UserAddService = UserAddService;
			_UserUpdateService = UserUpdateService;
			_UserCreateService = UserCreateService;
			_UserLoginService = UserLoginService;
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
				Username = r.Username,
				Email = r.Email,
				UserPets = r.UserPets,
			//	Species = r.Species,
			//	Age = r.Age,
			//	Habitat = r.Habitat,
			//	Weight = r.Weight,
			//	Description = r.Description,
			//	DateOfBirth = r.DateOfBirth
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
				Email = UserById.Email,
				
				//PasswordHash = UserById.PasswordHash,
				Username = UserById.Username,
				UserPets = UserById.UserPets,
				
			};
			return Ok(UserModel);
		}

		// POST api/<UsersController>
		[HttpPost]
		public async Task<ActionResult<IEnumerable<User>>> CreateUser([FromBody] User User)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var newUser = new UserEntity
			{
				Username = User.Username,
				Email = User.Email,
				PasswordHash = User.PasswordHash,
				//UserPets = User.UserPets
			};
			
			await _UserCreateService.CreateAsync(newUser);

			return CreatedAtAction(nameof(GetUserById), new { id = User.Id }, User);
		}
		[HttpPost("login")]
		public async Task<ActionResult<IEnumerable<User>>> LoginUser([FromBody] LoginRequest loginRequest)
		{

			if(loginRequest.Email == null || loginRequest.Password == null)
			{
				return BadRequest();
				
			}
			UserEntity LoggedUser = await _UserLoginService.LoginUserAsync(loginRequest.Email, loginRequest.Password);
			return CreatedAtAction(nameof(GetUserById), new { id = LoggedUser.Id }, LoggedUser);



		}
		// PUT api/<UsersController>/5
		[HttpPut("{id}")]
		public async Task<ActionResult<bool>> EditUser(Guid id,[FromBody] UpdateUserRequest User)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var editUser = new UserEntity
			{
				Username = User.Username,
				Email = User.Email
			//	Name = User.Name,
			//	Species = User.Species,
			//	Age = User.Age,
			//	Habitat = User.Habitat,
			//	Weight = User.Weight,
			//	Description = User.Description,
			//	DateOfBirth = User.DateOfBirth
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
