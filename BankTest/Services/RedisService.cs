using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;
using System.Text.Json;

namespace bankTest.Services
{
	public class RedisService : IRedisService
	{
		private readonly IDistributedCache? _cache;
		public RedisService(IDistributedCache cache)
		{
			_cache = cache;
		}
		public T GetCachedData<T>(string key)
		{
			var jsonData = _cache.GetString(key);
			if (jsonData == null)
				return default(T);
			return JsonSerializer.Deserialize<T>(jsonData);
		}
		public void SetCachedData<T>(string key, T data, TimeSpan cacheDuration)
		{
			var options = new DistributedCacheEntryOptions
			{
				AbsoluteExpirationRelativeToNow = cacheDuration
			};
			var jsonData = JsonSerializer.Serialize(data);
			_cache.SetString(key, jsonData, options);
		}

		public object RemoveData(string key) {
			var jsonData = _cache.GetString(key);
			if (jsonData == null)
				return default;

			_cache.Remove(key);
			return true;
        }
	}
}
