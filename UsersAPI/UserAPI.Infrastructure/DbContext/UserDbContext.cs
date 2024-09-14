using Microsoft.EntityFrameworkCore;
using UserAPI.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace UserAPI.Infrastructure.DbContext
{
	public class UserDbContext : Microsoft.EntityFrameworkCore.DbContext
	{
		public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

		public DbSet<UserEntity> Users { get; set; }

		
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<UserEntity>().ToTable("Users");

			modelBuilder.Entity<UserEntity>()
		.Property(u => u.UserPets)
		.HasConversion(
			v => JsonSerializer.Serialize(v, new JsonSerializerOptions()), // Convert List<Guid> to JSON string
			v => JsonSerializer.Deserialize<List<Guid>>(v, new JsonSerializerOptions())); // Convert JSON string back to List<Guid>
		

		string UsersJson = System.IO.File.ReadAllText("Users.json");
			List <UserEntity> Users = System.Text.Json.JsonSerializer.Deserialize<List<UserEntity>>(UsersJson);

			foreach (UserEntity User in Users)
			{
				modelBuilder.Entity<UserEntity>().HasData(User);
			}
		}
	}
}
