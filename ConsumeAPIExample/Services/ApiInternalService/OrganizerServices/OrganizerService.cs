using ConsumeAPIExample.Models.ApiInternal;
using ConsumeAPIExample.Models.ApiInternal.Organizer;
using ConsumeAPIExample.Utilities;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

namespace ConsumeAPIExample.Services.ApiInternalService.OrganizerServices
{
	public class OrganizerService : BaseInternalApiService, IOrganizerService
	{
		public OrganizerService(HttpClient httpClient, 
			ILogger<OrganizerService> logger,
			IOptions<VoxApi> voxApi,
			IConfiguration configuration)
			: base(httpClient, new Uri(configuration[ApplicationConstant.DOMAIN]), logger, voxApi)
		{
		}

		public OrganizerResponseModel? GetOrganizerList(OrganizerListRequestModel request)
		{
			var response = Do<OrganizerListRequestModel, PresignedResponseList>(request, 
																			ApplicationConstant.ApiRoute.ORGANIZER,
																			ApplicationConstant.MethodType.GET);
			var tokenData = response.Data;
			var tokenMeta = response.Meta;

			if (tokenData == null) return null;
			
			var data = tokenData.ToObject<List<DataOrganizer> >();
			var meta = tokenMeta!.ToObject<BaseFilterMetaResponseModel>();

			var result = new OrganizerResponseModel() 
			{
				Data = data,
				Meta = meta
			};
			
			return result;
		}

		public DataOrganizer PostOrganizer(OrganizerPostRequestModel request) 
		{
			var response = Do<OrganizerPostRequestModel, DataOrganizer>(request,
																			ApplicationConstant.ApiRoute.ORGANIZER,
																			ApplicationConstant.MethodType.POST);
			return response;
		}

		public DataOrganizer? DetailOrganizer(int id) 
		{
			string request = string.Empty;
			string url = $"{ApplicationConstant.ApiRoute.ORGANIZER}/{id}";
			string method = ApplicationConstant.MethodType.GET;

			var response = Do<string, DataOrganizer>(request,url, method);

			return response;
		}

		public void UpdateOrganizer(int id, OrganizerPostRequestModel request) 
		{
			string url = $"{ApplicationConstant.ApiRoute.ORGANIZER}/{id}";
			string method = ApplicationConstant.MethodType.PUT;

			Do<OrganizerPostRequestModel, DataOrganizer>(request, url, method);
		}

		public void DeleteOrganizer(int id) 
		{
			string request = string.Empty;
			string url = $"{ApplicationConstant.ApiRoute.ORGANIZER}/{id}";
			string method = ApplicationConstant.MethodType.DELETE;

			Do<string, DataOrganizer>(request, url, method);
		}

	}
}
