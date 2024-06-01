using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Cache.Service
{
	public class CacheCleanupService(ICacheService cacheService,
		ILogger<CacheCleanupService> logger)
		: BackgroundService
	{
		private readonly TimeSpan cleanupInterval = TimeSpan.FromHours(1);

		protected override async Task ExecuteAsync(CancellationToken cancellationToken)
		{
			while (!cancellationToken.IsCancellationRequested)
			{
				logger.LogInformation("Starting cache cleanup...");
				await cacheService.RemoveStaleCacheEntriesAsync();
				logger.LogInformation("Cache cleanup completed.");

				await Task.Delay(cleanupInterval, cancellationToken);
			}
		}
	}

}
