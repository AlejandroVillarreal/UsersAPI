using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAPI.Core.Domain.Entities;

namespace UserAPI.Core.ServiceContracts
{
	public interface IUserLoginService
	{
		Task<UserEntity> LoginUserAsync(String email, String password);
	}
}
