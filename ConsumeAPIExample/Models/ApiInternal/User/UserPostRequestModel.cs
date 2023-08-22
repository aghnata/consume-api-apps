using ConsumeAPIExample.Utilities.Validations;
using Newtonsoft.Json;

namespace ConsumeAPIExample.Models.ApiInternal.User
{
	[AllowedUserPostRequestModel]
	public class UserPostRequestModel : DataUser
	{
		[JsonProperty("password")]
		public string?Password { get; set; }


		[JsonProperty("repeatPassword")]
		public string? RepeatPassword { get; set; }
	}
}
