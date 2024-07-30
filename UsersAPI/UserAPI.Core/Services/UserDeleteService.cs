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
	public class UserDeleteService : IUserDeleteService
	{
		private readonly IUserRepository _UserRepository;
		public UserDeleteService(IUserRepository UserRepository)
		{
			_UserRepository = UserRepository;
		}
		public async Task<bool> DeleteAsync(Guid? id)
		{
			if (id != null)
			{
				UserEntity User = await _UserRepository.GetByIdAsync(id.Value);
				if(User != null)
				{
					await _UserRepository.DeleteAsync(id.Value);
				}
				
				return true;
			}
			return false;
		}
	}
}
