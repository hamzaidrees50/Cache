using Cache.Service;
using Carter;
using Newtonsoft.Json;
using System.Net;

namespace Cache.API.Endpoint
{
	public class CacheEndpoint : ICarterModule
	{
		public void AddRoutes(IEndpointRouteBuilder app)
		{
			app.MapPost("", async (CacheRequest request, ICacheService cacheService) =>
			{
				var cacheResponse = await cacheService.GetCachedResponseAsync(request.Key);
				if (cacheResponse is not null)
				{
					return Results.Ok(cacheResponse);
				}

				var responseData = JsonConvert.SerializeObject(request.Value);
				await cacheService.SetCachedResponseAsync(request.Key, responseData);

				return Results.Ok(request.Value);
			}).WithOpenApi()
			.Produces<object>((int)HttpStatusCode.OK);
		}
	}
}
