using ConsumeAPIExample.Models.ApiInternal.Organizer;
using Newtonsoft.Json;

namespace ConsumeAPIExample.Models.ApiInternal.User
{
	public class UserResponseModel
	{
		public List<DataUser>? Data { get; set; }
		public BaseFilterMetaResponseModel? Meta { get; set; }
	}

	public class DataUser 
	{
		[JsonProperty("firstName")]
		public string? FirstName { get; set; }


		[JsonProperty("lastName")]
		public string? LastName { get; set; }


		[JsonProperty("email")]
		public string? Email { get; set; }
	}

	public class UserPostResponseModel : DataUser
	{
        public int Id { get; set; }
    }

}
