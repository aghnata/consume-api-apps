using System.Net;

namespace ConsumeAPIExample.Models.ApiInternal
{
	public class Response
	{
		public HttpStatusCode StatusCode { get; set; }

		public string Content { get; set; }
	}
}
