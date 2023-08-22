using Newtonsoft.Json;

namespace ConsumeAPIExample.Models.ApiInternal.Organizer
{
	public class OrganizerPostRequestModel
	{
		[JsonProperty("organizerName")]
		public string? OrganizerName { get; set; }

		[JsonProperty("imageLocation")]
		public string? ImageLocation { get; set; }
	}
}
