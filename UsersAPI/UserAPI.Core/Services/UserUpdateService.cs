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
	public class UserUpdateService : IUserUpdateService
	{
		private readonly IUserRepository _UserRepository;
		public UserUpdateService(IUserRepository UserRepository)
		{
			_UserRepository = UserRepository;
		}
		public async Task<UserEntity> UpdateUserAsync(Guid id,UserEntity? User)
		{
			UserEntity? editedUser = await _UserRepository.GetUserByIdAsync(id);
			if(editedUser == null)
			{
				throw new ArgumentException("User with the given Id was not found");
			}
			editedUser.Username = User.Username;
			editedUser.Email = User.Email;
			//editedUser.Weight = User.Weight;
			//editedUser.Age = User.Age;
			//editedUser.Habitat = User.Habitat;
			//editedUser.Age = User.Age;
			// editedUser.DateOfBirth = User.DateOfBirth;
			//editedUser.Description = User.Description;
			//editedUser.Species = User.Species;


			ValidationContext validationContext = new ValidationContext(editedUser);
			List<ValidationResult> validationResults = new List<ValidationResult>();
			bool isValid = Validator.TryValidateObject(editedUser, validationContext, validationResults, true);
			if (!isValid)
			{
				throw new ArgumentException(validationResults.FirstOrDefault()?.ErrorMessage);
			}
			
			await _UserRepository.UpdateUserAsync(id,editedUser);

			return User;
		}
	}
}
