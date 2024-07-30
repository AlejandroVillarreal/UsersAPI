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
	public class UserGetByIdService : IUserGetByIdService
	{
		private readonly IUserRepository _UserRepository;
		public UserGetByIdService(IUserRepository UserRepository)
		{
			_UserRepository = UserRepository;
		}
		public async Task<UserEntity> GetByIdAsync(Guid? id)
		{

			if (id != null)
			{
				UserEntity? UserById = await _UserRepository.GetByIdAsync(id.Value);
				if (UserById != null)
				{
					return UserById;
				}
				throw new ArgumentException("Given User id doesn't exist");
			}
			throw new ArgumentException("User id is invalid");


		}
	}
}
