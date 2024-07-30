using UserAPI.Core.Domain.Entities;
using UserAPI.Core.Domain.RepositoryContracts;
using UserAPI.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAPI.Core.Services
{
	public class UserGetAllService : IUserGetAllService
	{
		private readonly IUserRepository _UserRepository;
		public UserGetAllService(IUserRepository UserRepository) { 
			_UserRepository = UserRepository;
		}

		public async Task<IEnumerable<UserEntity>> GetAllUsersAsync()
		{
			IEnumerable<UserEntity> Users = new List<UserEntity>();
			Users = await _UserRepository.GetAllUsersAsync();
			return Users;
			
		}
		
	}
}
