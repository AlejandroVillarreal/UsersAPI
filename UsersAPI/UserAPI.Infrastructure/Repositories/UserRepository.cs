using Microsoft.EntityFrameworkCore;
using UserAPI.Core.Domain.Entities;
using UserAPI.Core.Domain.RepositoryContracts;
using UserAPI.Infrastructure.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAPI.Infrastructure.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly UserDbContext _db;
		public UserRepository(UserDbContext db)
		{
			_db = db;
		}

		public async Task<UserEntity> CreateAsync(UserEntity? entity)
		{
			if (entity != null) {
				_db.Users.Add(entity);
				await _db.SaveChangesAsync();
				return entity;
			}
			throw new ArgumentException("User can't be null");


		}

		public async Task<bool> AddUserToUserAsync(UserEntity? entity, Guid UserId)
		{
			if (entity != null)
			{
				UserEntity UserFromDb = _db.Users.Find(entity.Id);
				if(UserFromDb != null)
				{
					UserFromDb.UserPets.Add(UserId);
					int rowsAffected = await _db.SaveChangesAsync();
					return rowsAffected > 0;
				}
				throw new ArgumentException("User not found");


			}
			throw new ArgumentException("User can't be null");


		}

		public async Task<bool> DeleteAsync(Guid? id)
		{

			
			_db.Users.RemoveRange(_db.Users.Where(User => User.Id == id));
			int rowsDeleted = await _db.SaveChangesAsync();
			return rowsDeleted > 0;
		}

		public async Task<IEnumerable<UserEntity>> GetAllUsersAsync()
		{
			//IEnumerable<UserEntity> Users = await _db.Users.OrderByDescending(order => order.Name).ToListAsync();
			//return Users;
			throw new NotImplementedException();
		}

		public async Task<UserEntity> LoginAsync(Guid? id)
		{
			UserEntity UserById = await _db.Users.FirstOrDefaultAsync(User => User.Id == id);
			return UserById;
		}
		public async Task<UserEntity> GetUserAsync(String Email)
		{
			UserEntity UserById = await _db.Users.FirstOrDefaultAsync(User => User.Email == Email);
			return UserById;
		}
		public async Task<UserEntity> UpdateUserAsync(UserEntity? User)
		{
			//UserEntity? matchingUser = await _db.Users.FirstOrDefaultAsync(User => User.Id == User.Id);
			//if (matchingUser != null)
			//{

			//	matchingUser.Name = User.Name;
			//	matchingUser.Habitat = User.Habitat;
			//	matchingUser.DateOfBirth = User.DateOfBirth;
			//	matchingUser.Weight = User.Weight;
			//	matchingUser.Age = User.Age;
			//	matchingUser.Species = User.Species;
			//	matchingUser.Description = User.Description;

			//	await _db.SaveChangesAsync();
			//	return matchingUser;
			//}
			//return User;
			throw new NotImplementedException();
		}
			
	}
}
