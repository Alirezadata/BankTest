using BankTest.Context;
using bankTest.Services;

namespace BankTest.ConfigureServices
{
	public class RedisManagementConfigure
	{
		public static void Configure(IServiceCollection services, string redisConnectionString)
		{
			services.AddStackExchangeRedisCache(
			options =>
			{
				options.Configuration = redisConnectionString;
				options.InstanceName = "MyRedisCache";
			});
		}
	}
}
