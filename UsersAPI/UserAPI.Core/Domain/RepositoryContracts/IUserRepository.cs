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
		Task<UserEntity> AddAsync(UserEntity? entity);
		Task<bool> DeleteAsync(Guid? id);
		Task<IEnumerable<UserEntity>> GetAllUsersAsync();
		Task<UserEntity> GetByIdAsync(Guid? id);
		Task<UserEntity> UpdateUserAsync(UserEntity? entity);

	}
}
