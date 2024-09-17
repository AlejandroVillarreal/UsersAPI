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
		
		public async Task<UserEntity> LoginUserAsync(string UserEmail, string UserPassword)
		{
			if (UserEmail != null)
			{
				UserEntity? UserByEmail = await _UserRepository.GetUserAsync(UserEmail);
				if (UserByEmail != null)
				{
					if(!PasswordHelper.VerifyPassword(UserPassword, UserByEmail.PasswordHash, UserByEmail.PasswordSalt))
					{
						throw new ArgumentException("Incorrect password");
					}
					return UserByEmail;
				}
				throw new ArgumentException("Given User id doesn't exist");
			}
			throw new ArgumentException("User id is invalid");
			
		}
	}
}
