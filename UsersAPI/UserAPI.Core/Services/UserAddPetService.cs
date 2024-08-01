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
	public class UserAddPetService : IUserAddPetService
	{
		private readonly IUserRepository _UserRepository;

		public UserAddPetService(IUserRepository UserRepository)
		{
			_UserRepository = UserRepository;
		}
		public async Task AddPetAsync(Guid userId, UserPetEntity UserPet)
		{

			if (UserPet == null)
			{
				throw new ArgumentNullException(nameof(UserPet));
			}

			_UserRepository.AddPetToUserAsync(UserPet.UserId);
			
		}
	}
}
