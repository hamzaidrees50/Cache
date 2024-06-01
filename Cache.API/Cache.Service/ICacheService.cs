namespace Cache.Service
{
	public interface ICacheService
	{
		Task<string?> GetCachedResponseAsync(string cacheKey);
		Task SetCachedResponseAsync(string cacheKey, string responseData);
		Task RemoveStaleCacheEntriesAsync();
	}
}
