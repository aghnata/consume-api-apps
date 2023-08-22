namespace ConsumeAPIExample.Models.ApiInternal.Organizer
{
	public class OrganizerResponseModel
	{
        public List<DataOrganizer>? Data { get; set; }
        public BaseFilterMetaResponseModel? Meta { get; set; }
    }

	public class DataOrganizer : OrganizerPostRequestModel
	{
		public int? Id { get; set; } 
	}
}
