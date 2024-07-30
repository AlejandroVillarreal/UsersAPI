using UserAPI.Core.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace UserAPI.Core.ServiceContracts
{
	public interface IUserCreateService
	{
		Task<UserEntity> CreateAsync(UserEntity? entity);
	}
}