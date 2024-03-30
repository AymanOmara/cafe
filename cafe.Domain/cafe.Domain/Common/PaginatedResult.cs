namespace cafe.Domain.Common
{
	public class PaginatedResult<T>
	{
		public required T? data { get; set; }

		public required int CurrentPage { get; set; }

		public required int TotalCount { get; set; }
	}
}

