using System;
using System.ComponentModel.DataAnnotations;
using UserAPI.Core.Domain.Entities;
using UserAPI.Core.Domain.RepositoryContracts;
using UserAPI.Core.ServiceContracts;
using UserAPI.Core.Services.Helpers;

namespace UserAPI.Core.Services
{
	public class UserCreateService : IUserCreateService
	{
		private readonly IUserRepository _UserRepository;

		public UserCreateService(IUserRepository UserRepository)
		{
			_UserRepository = UserRepository;
		}

		public async Task<UserEntity> CreateAsync(UserEntity? User)
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
			User.PasswordHash = PasswordHelper.HashPassword(User.PasswordHash);
			await _UserRepository.CreateAsync(User);

			return User;

		}
	}
}