using ConsumeAPIExample.Models.ApiInternal;
using ConsumeAPIExample.Models.ApiInternal.Organizer;
using ConsumeAPIExample.Models.ApiInternal.User;
using ConsumeAPIExample.Services.ApiInternalService.UserServices;
using ConsumeAPIExample.Utilities;
using Microsoft.Extensions.Options;

namespace ConsumeAPIExample.Services.ApiInternalService.UserServices
{
    public class UserService : BaseInternalApiService, IUserService
    {
		public UserService(HttpClient httpClient,
			ILogger<UserService> logger,
			IOptions<VoxApi> voxApi,
			IConfiguration configuration)
			: base(httpClient, new Uri(configuration[ApplicationConstant.DOMAIN]), logger, voxApi)
		{
		}

		public UserPostResponseModel PostUser(UserPostRequestModel request) 
		{
			var response = Do<UserPostRequestModel, UserPostResponseModel>(request,
																			ApplicationConstant.ApiRoute.USER,
																			ApplicationConstant.MethodType.POST);
			return response;
		}


	}
}
