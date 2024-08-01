using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UserAPI.Core.Domain.Entities;
using UserAPI.Core.Domain.RepositoryContracts;
using UserAPI.Core.ServiceContracts;
using UserAPI.Core.Services.Helpers;

namespace UserAPI.Core.Services
{
	public class UserLoginService : IUserLoginService
	{
		private readonly IUserRepository _UserRepository;
		public UserLoginService(IUserRepository UserRepository)
		{
			_UserRepository = UserRepository;
		}
		
		public async Task<UserEntity> LoginUserAsync(UserEntity? User)
		{
			if (User != null)
			{
				UserEntity? UserById = await _UserRepository.LoginAsync(User.Id);
				if (UserById != null)
				{
					if(!PasswordHelper.VerifyPassword(User.PasswordHash, UserById.PasswordHash))
					{
						throw new ArgumentException("Incorrect password");
					}
					return UserById;
				}
				throw new ArgumentException("Given User id doesn't exist");
			}
			throw new ArgumentException("User id is invalid");
			
		}
	}
}
