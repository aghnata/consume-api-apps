using ConsumeAPIExample.Models.ApiInternal;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Net.Http.Headers;
using ConsumeAPIExample.Utilities;

namespace ConsumeAPIExample.Services.ApiInternalService
{
	public class BaseInternalApiService
	{
		#region Properties
		protected readonly HttpClient HttpClient;
		protected readonly Uri BaseUri;
		private readonly ILogger<BaseInternalApiService> Logger;
		private readonly VoxApi _voxApi;
		#endregion

		#region Constructor
		public BaseInternalApiService(HttpClient httpClient, 
			Uri baseUri,
			ILogger<BaseInternalApiService> logger, 
			IOptions<VoxApi> voxApi)
		{
			_voxApi = voxApi.Value;
			HttpClient = httpClient;
			BaseUri = baseUri;
			Logger = logger;

			var token = GetAccessToken().Result;
			HttpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
		}
		#endregion

		#region private method
		private async Task<string> GetAccessToken()
		{
			var formContent = new Dictionary<string, string>
			 {
				 { "email", _voxApi.Email },
				 { "password", _voxApi.Password }
			 };
			var url = _voxApi.BaseUrl + _voxApi.UriConnectToken;
			
			var result = await HttpClient.SendAsync(new HttpRequestMessage
			{
				Method = HttpMethod.Post,
				Content = new FormUrlEncodedContent(formContent),
				RequestUri = new Uri(url)
			});
			var authenticationResponse = await result.Content.ReadAsStringAsync();
			var data = JsonConvert.DeserializeObject<Dictionary<string, JToken>>(authenticationResponse);

			return data["token"].ToString();
		}
		#endregion

		#region Public Methods

		public TOut Do<TIn, TOut>(TIn request, string endpoint, string methodType) where TIn : class
		{
			if (request == null)
			{
				throw new ArgumentNullException(nameof(request));
			}

			var baseUrl = BaseUri.AbsoluteUri;
			var url = new Uri(new Uri(baseUrl + (baseUrl.EndsWith('/') ? "" : "/")), endpoint);

			var method = methodType switch
			{
				ApplicationConstant.MethodType.POST => HttpMethod.Post,
				ApplicationConstant.MethodType.PUT => HttpMethod.Put,
				ApplicationConstant.MethodType.DELETE => HttpMethod.Delete,
				_ => HttpMethod.Get
			};

			var httpRequest = new HttpRequestMessage
			{
				Method = method,
				RequestUri = url
			};

			var requestContent = JsonConvert.SerializeObject(request);
			httpRequest.Content = new StringContent(requestContent, Encoding.UTF8);
			httpRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json; charset=utf-8");

			Logger.LogInformation($"Trying to get data from API '{url}'. Request '{requestContent}'");

			var httpResponse = Task.Run(() => HttpClient.SendAsync(httpRequest)).GetAwaiter().GetResult();

			var statusCode = httpResponse.StatusCode;
			string responseContent = null;

			if (statusCode != HttpStatusCode.OK && statusCode != HttpStatusCode.NoContent && statusCode != HttpStatusCode.NotFound)
			{
                var ex = new Exception(
					$"An error has occurred while trying to get data from internal API. The process returned an invalid status code '{statusCode}'.");

				responseContent = Task.Run(() => httpResponse.Content.ReadAsStringAsync()).GetAwaiter().GetResult();

				var requestData = new Request
				{
					Content = requestContent,
					RequestUri = httpRequest.RequestUri,
					Method = httpRequest.Method
				};

				var responseData = new Response
				{
					Content = responseContent,
					StatusCode = httpResponse.StatusCode
				};

				httpRequest.Dispose();
				httpResponse.Dispose();

				throw ex;
			}

			TOut result;

			responseContent = Task.Run(() => httpResponse.Content.ReadAsStringAsync()).GetAwaiter().GetResult();

			result = JsonConvert.DeserializeObject<TOut>(responseContent);

			Logger.LogInformation($"Result data from API '{url}' with Request '{requestContent}'" +
									$". Response '{responseContent}'");

			return result;
		}

		#endregion


	}
}
