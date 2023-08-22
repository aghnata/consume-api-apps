using ConsumeAPIExample.Models.ApiInternal.Organizer;

namespace ConsumeAPIExample.Services.ApiInternalService.OrganizerServices
{
	public interface IOrganizerService
	{
		public OrganizerResponseModel? GetOrganizerList(OrganizerListRequestModel request);
		public DataOrganizer PostOrganizer(OrganizerPostRequestModel request);
		public DataOrganizer? DetailOrganizer(int id);
		public void UpdateOrganizer(int id, OrganizerPostRequestModel requestModel);
		public void DeleteOrganizer(int id);
	}
}
