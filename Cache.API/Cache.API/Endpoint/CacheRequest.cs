namespace Cache.API.Endpoint
{
	public record CacheRequest
	{
		public required string Key { get; set; }
		public required object Value { get; set; }
	}
}
