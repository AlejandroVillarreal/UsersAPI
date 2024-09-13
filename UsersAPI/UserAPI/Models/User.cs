using UserAPI.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace UserAPI.Models
{
	public class User
	{
		public Guid Id { get; set; }

		[Required()]
		[MaxLength(100)]
		public string Username { get; set; }
		
		[Required()]
		public string PasswordHash { get; set; }
		
		[Required()]
		public string Email { get; set; }

		public List<Guid> UserUsers { get; set; } = new List<Guid>();
	}
	
}
