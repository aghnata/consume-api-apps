using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using ConsumeAPIExample.Models.ApiInternal.User;

namespace ConsumeAPIExample.Utilities.Validations
{
	public class AllowedUserPostRequestModel : ValidationAttribute
	{
		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			var request = value as UserPostRequestModel;

			var success = ValidationResult.Success;
			
			ValidationResult? result = CheckEmailFormat(request!.Email!);
			if (result == success) result = CheckPasswordAndRepeatPasswordIsSame(request.Password, request.RepeatPassword);

			return result;
		}

		private static ValidationResult? CheckEmailFormat(string email)
		{
			if (!string.IsNullOrEmpty(email))
			{
				var firstArrEmail = email.Split('@');
				if (firstArrEmail?.Length < 2)
					return new ValidationResult($"Format email is not valid");

				var secondArrEmail = email.Split('.');
				if (secondArrEmail?.Length < 2)
					return new ValidationResult($"Format email is not valid");
			}
			else
				return new ValidationResult($"Email must be filled");

			string emailWithoutDomain = email.Split('@')[0];

			int lengtWord = emailWithoutDomain.Length;
			char firstChar = emailWithoutDomain[0];
			char lastChar = emailWithoutDomain[lengtWord - 1];

			if (firstChar == '.' || lastChar == '.')
				return new ValidationResult($"Format email is not valid");

			if (emailWithoutDomain.Split('.').Length > 2)
				return new ValidationResult($"Format email is not valid");

			if (!Regex.IsMatch(email, @"^[a-z0-9._%-\\!#$%*+-/=?^_`{}|~]+@[a-z0-9.-]+.[a-z]{2,}$", RegexOptions.None, TimeSpan.FromMilliseconds(500)))
				return new ValidationResult($"Format email is not valid");


			return ValidationResult.Success;
		}

		private static ValidationResult? CheckPasswordAndRepeatPasswordIsSame(string passwd, string repPasswd) 
		{
            if (passwd != repPasswd)
				return new ValidationResult($"Password and repeat password is different");
			
            return ValidationResult.Success;
		}


	}
}
