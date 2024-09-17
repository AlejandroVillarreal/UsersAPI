using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UserAPI.Core.Services.Helpers
{
	public static class PasswordHelper
	{
		// Generate a random salt
		public static string GenerateSalt(int size = 16)
		{
			var saltBytes = new byte[size];
			RandomNumberGenerator.Fill(saltBytes);
			return Convert.ToBase64String(saltBytes);
		}

		public static string HashPassword(string password, string salt)
		{
			using (var sha256 = SHA256.Create())
			{
				var saltedPassword = $"{password}{salt}";
				var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
				return Convert.ToBase64String(hashBytes);
			}
		}

		public static bool VerifyPassword(string password, string storedHash, string storedSalt)
		{
			var hash = HashPassword(password,storedSalt);
			return hash == storedHash;
			
		}
	}
}
