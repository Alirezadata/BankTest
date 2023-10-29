using bankTest.Services;
using BankTest.Context;
using Microsoft.EntityFrameworkCore;

namespace WarehousingPrj.ConfigureServices
{
	public class DIManagementConfigure
	{
		public static void Configure(IServiceCollection services)
		{
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddScoped<IBankContext, BankContext>();
			services.AddScoped<IRedisService, RedisService>();
		}
	}
}
