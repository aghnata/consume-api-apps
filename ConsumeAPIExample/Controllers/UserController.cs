using ConsumeAPIExample.Models.ApiInternal.User;
using ConsumeAPIExample.Services.ApiInternalService.UserServices;
using ConsumeAPIExample.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace ConsumeAPIExample.Controllers
{
	[ApiController]
	[Route(ApplicationConstant.ApiRoute.USER)]
	public class UserController
	{
		private readonly ILogger<UserController> _logger;
		private readonly IUserService _userService;

		public UserController(ILogger<UserController> logger,
			IUserService userService)
		{
			_logger = logger;
			_userService = userService;
		}

		[HttpPost]
		public UserPostResponseModel Post([FromBody] UserPostRequestModel requestModel)
		{
			return _userService.PostUser(requestModel);
		}


	}

}
