using ConsumeAPIExample.Models.ApiInternal.Organizer;
using ConsumeAPIExample.Services.ApiInternalService.OrganizerServices;
using ConsumeAPIExample.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace ConsumeAPIExample.Controllers
{
	[ApiController]
	[Route(ApplicationConstant.ApiRoute.ORGANIZER)]
	public class OrganizerController : ControllerBase
	{
		private readonly ILogger<OrganizerController> _logger;
		private readonly IOrganizerService _orgService;

		public OrganizerController(ILogger<OrganizerController> logger,
			IOrganizerService orgService)
		{
			_logger = logger;
			_orgService = orgService;
		}

		[HttpGet]
		public OrganizerResponseModel? Get([FromQuery] OrganizerListRequestModel requestModel)
		{
			return _orgService.GetOrganizerList(requestModel);
		}

		[HttpPost]
		public DataOrganizer Post([FromBody] OrganizerPostRequestModel requestModel)
		{
			return _orgService.PostOrganizer(requestModel);
		}

		[HttpGet("{id}")]
		public DataOrganizer? GetDetail(int id)
		{
			return _orgService.DetailOrganizer(id);
		}

		[HttpPut("{id}")]
		public void Update(int id, [FromBody] OrganizerPostRequestModel requestModel)
		{
			_orgService.UpdateOrganizer(id, requestModel);
		}

		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			_orgService.DeleteOrganizer(id);
		}

	}
}
