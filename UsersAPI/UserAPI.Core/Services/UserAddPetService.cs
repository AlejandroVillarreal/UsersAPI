using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAPI.Core.Domain.Entities;
using UserAPI.Core.Domain.RepositoryContracts;
using UserAPI.Core.ServiceContracts;

namespace UserAPI.Core.Services
{
	public class UserAddUserService : IUserAddUserService
	{
		private readonly IUserRepository _UserRepository;

		public UserAddUserService(IUserRepository UserRepository)
		{
			_UserRepository = UserRepository;
		}
		public async Task AddUserToUserAsync(Guid UserId, UserUserEntity UserUser)
		{

			if (UserUser == null)
			{
				throw new ArgumentNullException(nameof(UserUser));
			}

			//_UserRepository.AddUserToUserAsync(UserUser.UserId);
			
		}
	}
}
