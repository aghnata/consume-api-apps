using Newtonsoft.Json.Linq;

namespace ConsumeAPIExample.Models.ApiInternal
{
	public class PresignedResponseList
	{
		public JToken? Data { get; set; }
		public JToken? Meta { get; set; }
	}
}
