using System.ComponentModel.DataAnnotations;

namespace UserAPI.Models
{
	public class UpdateUserRequest
	{
		[Required()]
		public string Email { get; set; }
		
		[Required()]
		[MaxLength(100)]
		public string Username { get; set; }
		
	}
}
