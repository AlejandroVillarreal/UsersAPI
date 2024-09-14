using Microsoft.EntityFrameworkCore;
using UserAPI.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Text.Json.Serialization;

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


			var petsConverter = new ValueConverter<List<Guid>, string>(
		   v => JsonSerializer.Serialize(v, new JsonSerializerOptions { WriteIndented = false }),
		   v => JsonSerializer.Deserialize<List<Guid>>(v, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
	   );

			var petsComparer = new ValueComparer<List<Guid>>(
				(c1, c2) => c1.SequenceEqual(c2), // Compare if sequences are equal
				c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())), // Calculate hashcode
				c => c.ToList() // Deep copy the list
			);



			string UsersJson = System.IO.File.ReadAllText("Users.json");
			List<UserEntity> Users = System.Text.Json.JsonSerializer.Deserialize<List<UserEntity>>(UsersJson);

			foreach (UserEntity User in Users)
			{
				modelBuilder.Entity<UserEntity>().Property(u => u.UserPets)
			.HasConversion(petsConverter) // Apply the value converter
			.Metadata.SetValueComparer(petsComparer); // Apply the value comparer
				modelBuilder.Entity<UserEntity>().HasData(User);
			}



		}
	}
}
