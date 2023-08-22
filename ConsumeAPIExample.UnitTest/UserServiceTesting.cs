using ConsumeAPIExample.Models.ApiInternal.User;
using Moq;
using System.ComponentModel.DataAnnotations;

namespace ConsumeAPIExample.UnitTest
{
	public class UserServiceTesting
	{
		private readonly Mock<IServiceProvider> _serviceProvider;

		public UserServiceTesting()
		{
			_serviceProvider = new Mock<IServiceProvider>();
		}

		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void AllowedUserPostRequestModelTesting()
		{
			UserPostRequestModel requestModel = new()
			{
				FirstName = "User",
				LastName = "New1",
				Email = "usernew@gmail.com",
				Password = "123Abc!@",
				RepeatPassword = "123Abc!@"
			};

			var validationResults = new System.Collections.Generic.List<ValidationResult>();
			var validationContext = new ValidationContext(requestModel, _serviceProvider.Object, null);

			var result = Validator.TryValidateObject(requestModel, validationContext, validationResults, true);

			Assert.That(true, Is.EqualTo(result));
		}

		[Test]
		public void AllowedUserPostRequestModelMissmatchPasswordTesting()
		{
			UserPostRequestModel requestModel = new()
			{
				FirstName = "User",
				LastName = "New1",
				Email = "usernew@gmail.com",
				Password = "123Abc!@",
				RepeatPassword = "Abc!@123"
			};

			var validationResults = new System.Collections.Generic.List<ValidationResult>();
			var validationContext = new ValidationContext(requestModel, _serviceProvider.Object, null);

			var result = Validator.TryValidateObject(requestModel, validationContext, validationResults, true);

			Assert.That(false, Is.EqualTo(result));
		}

	}
}