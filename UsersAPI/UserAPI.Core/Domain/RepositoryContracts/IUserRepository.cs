using UserAPI.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAPI.Core.Domain.RepositoryContracts
{
	public interface IUserRepository
	{
		Task<UserEntity> CreateAsync(UserEntity? entity);
		Task<UserEntity> LoginAsync(Guid? id);
		Task<bool> AddPetToUserAsync(UserEntity? entity, Guid petId);


		//----------------WIP----------------------------------------------------------------
		Task<bool> DeleteAsync(Guid? id);
		Task<IEnumerable<UserEntity>> GetAllUsersAsync();
		Task<UserEntity> UpdateUserAsync(UserEntity? entity);

	}
}
