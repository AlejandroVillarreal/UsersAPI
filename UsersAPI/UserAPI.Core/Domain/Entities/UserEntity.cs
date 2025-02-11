﻿using UserAPI.Core.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace UserAPI.Core.Domain.Entities
{
	public class UserEntity
	{
		[Key]
		public Guid Id { get; set; }

		[Required(ErrorMessage = "Username is required.")]
		[MaxLength(100)]
		public string Username { get; set; }

		[Required(ErrorMessage = "Password is required.")]
		public string PasswordHash { get; set; }
		

		[Required(ErrorMessage = "Email is required.")]
		public string Email { get; set; }

		public List<Guid> UserPets { get; set; } = new List<Guid>();

		public string PasswordSalt { get; set; }
	}
	
	
}
