﻿using Newtonsoft.Json;

namespace ConsumeAPIExample.Models.ApiInternal
{
	public class BaseFilterMetaResponseModel
	{
		public Pagination Pagination { get; set; } = null!;
    }

	public class Pagination
	{
		public int Total { get; set; }
		public int Count { get; set; }
		
		[JsonProperty("per_page")]
		public int PerPage { get; set; }
		
		[JsonProperty("current_page")]
		public int CurrentPage { get; set; }
		
		[JsonProperty("total_pages")]
		public int TotalPages { get; set; }

		public Link? Links { get; set; }
    }

	public class Link 
	{
        public string? Next { get; set; }
    }


}
