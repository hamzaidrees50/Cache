using Database;
using Microsoft.EntityFrameworkCore;

namespace Cache.Service
{
	public class CacheService(CacheDbContext cacheDbContext) : ICacheService
	{
		public async Task<string?> GetCachedResponseAsync(string cacheKey)
		{
			var cache = await cacheDbContext.Caches
				.FirstOrDefaultAsync(x => x.CacheKey == cacheKey && x.CreatedAt.AddHours(2) < DateTime.Now);
			return cache is not null ? cache!.Response : null;
		}

		public async Task SetCachedResponseAsync(string cacheKey, string responseData)
		{
			var cacheData = new Database.Cache
			{
				CacheKey = cacheKey,
				Response = responseData,
				CreatedAt = DateTime.Now
			};
			await cacheDbContext.Caches.AddAsync(cacheData);
			await cacheDbContext.SaveChangesAsync();
		}

		public async Task RemoveStaleCacheEntriesAsync()
		{
			var cachedData = cacheDbContext.Caches
				.Where(x => x.CreatedAt.AddHours(2) >= DateTime.Now)
				.AsEnumerable();
			cacheDbContext.Caches.RemoveRange(cachedData);
			await cacheDbContext.SaveChangesAsync();
		}
	}
}
