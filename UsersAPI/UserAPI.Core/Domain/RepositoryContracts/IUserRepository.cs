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
		Task<UserEntity> GetUserAsync(String Email);
		Task<UserEntity> GetUserByIdAsync(Guid? id);
		Task<bool> AddUserToUserAsync(UserEntity? entity, Guid UserId);
		Task<bool> DeleteAsync(Guid? id);
		Task<UserEntity> UpdateUserAsync(Guid id,UserEntity? entity);
		Task<IEnumerable<UserEntity>> GetAllUsersAsync();
		//----------------WIP----------------------------------------------------------------

		//


	}
}
