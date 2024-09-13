using UserAPI.Core.Domain.Entities;
using UserAPI.Core.Domain.RepositoryContracts;
using UserAPI.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAPI.Core.Services
{
	public class UserAddService : IUserAddService
	{
		private readonly IUserRepository _UserRepository;
		
		public UserAddService(IUserRepository UserRepository) {
			_UserRepository = UserRepository;
		}

		public async Task<UserEntity> AddAsync(UserEntity? User)
		{
			if (User == null)
			{
				throw new ArgumentNullException(nameof(User));
			}
			//Entity Validation
			ValidationContext validationContext = new ValidationContext(User);
			List<ValidationResult> validationResults = new List<ValidationResult>();
			bool isValid = Validator.TryValidateObject(User, validationContext, validationResults, true);
			if (!isValid)
			{
				throw new ArgumentException(validationResults.FirstOrDefault()?.ErrorMessage);
			}
			//If valid assign a new Guid to User
			User.Id = Guid.NewGuid();
			await _UserRepository.CreateAsync(User);
			
			return User;
		}
	}
}
