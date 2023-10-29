using BankTest.Context;
using Microsoft.EntityFrameworkCore;

namespace WarehousingPrj.ConfigureServices
{
	public class ContextManagementConfigure
	{
		public static void Configure(IServiceCollection services, string conString)
		{
			services.AddDbContext<BankContext>(x => x.UseSqlServer(conString));
		}
	}
}
