using System;
using UserAPI.Core.Domain.Entities;
using UserAPI.Core.ServiceContracts;

namespace UserAPI.Core.Services
{
	public class UserCreateService : IUserCreateService
	{
		
		public Task<UserEntity> CreateAsync(UserEntity? entity)
		{
			var user = new User
			{
				Id = Guid.NewGuid(),
				Username = userDto.Username,
				PasswordHash = HashPassword(userDto.Password),
				Email = userDto.Email
			};

			_context.Users.Add(user);
			await _context.SaveChangesAsync();

			return user;
		}
	}
}