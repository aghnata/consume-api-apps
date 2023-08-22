namespace ConsumeAPIExample.Models.ApiInternal
{
	public class Request
	{
		public HttpMethod Method { get; set; }

		public Uri RequestUri { get; set; }

		public string Content { get; set; }
	}
}
