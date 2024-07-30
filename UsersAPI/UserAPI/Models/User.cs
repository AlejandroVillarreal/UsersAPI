using UserAPI.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace UserAPI.Models
{
	public class User
	{
		public Guid Id { get; set; }

		[Required()]
		[MaxLength(100)]
		public string Name { get; set; }

		[Required]
		public string Species { get; set; }
		
		[Range(0, int.MaxValue)]
		public int Age { get; set; }

		[Required()]
		public string Habitat { get; set; }

		[Range(0,float.MaxValue)]
		public float Weight { get; set; }

		public string? Description { get; set; }

		[Required()]
		public DateTime DateOfBirth { get; set; }

		
	}
}
