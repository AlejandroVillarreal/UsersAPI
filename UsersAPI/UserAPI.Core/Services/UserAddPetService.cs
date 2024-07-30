using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAPI.Core.Domain.Entities;
using UserAPI.Core.ServiceContracts;

namespace UserAPI.Core.Services
{
	public class UserAddPetService : IUserAddPetService
	{
		public Task AddPetAsync(Guid userId, UserPetEntity UserPet)
		{
			throw new NotImplementedException();
		}
	}
}
