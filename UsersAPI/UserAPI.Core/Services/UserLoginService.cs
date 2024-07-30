using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAPI.Core.Domain.Entities;
using UserAPI.Core.ServiceContracts;

namespace UserAPI.Core.Services
{
	public class UserLoginService : IUserLoginService
	{
		public Task<UserEntity> LoginUserAsync(UserEntity? entity)
		{
			throw new NotImplementedException();
		}
	}
}
