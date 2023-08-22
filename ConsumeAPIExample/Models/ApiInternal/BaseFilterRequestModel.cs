using Newtonsoft.Json;

namespace ConsumeAPIExample.Models.ApiInternal
{
	public class BaseFilterRequestModel
	{
		[JsonProperty("page")]
		public int Page { get; set; } = 1;

		[JsonProperty("perPage")]
		public int PerPage { get; set; } = 10;
    }
}
