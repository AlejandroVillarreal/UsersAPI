using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAPI.Core.Validators
{
	public class ValidDateOfBirthAttribute : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value == null)
			{
				return null;
			}

			DateTime dateOfBirth = Convert.ToDateTime(value);


			if (dateOfBirth > DateTime.UtcNow)
			{
				return new ValidationResult("Date of Birth cannot be in the future.");
				
			} else
			{
				return ValidationResult.Success;
			}

			
		}
	}
}

