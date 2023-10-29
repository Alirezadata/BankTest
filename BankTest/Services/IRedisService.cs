namespace bankTest.Services
{
	public interface IRedisService
	{
		T GetCachedData<T>(string key);
		void SetCachedData<T>(string key, T data, TimeSpan cacheDuration);
		object RemoveData(string key);
	}
}