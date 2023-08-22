using ConsumeAPIExample.Models.ApiInternal.User;

namespace ConsumeAPIExample.Services.ApiInternalService.UserServices
{
    public interface IUserService
    {
		public UserPostResponseModel PostUser(UserPostRequestModel request);
	}
}
