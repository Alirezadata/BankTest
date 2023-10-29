using Microsoft.EntityFrameworkCore;

namespace WarehousingPrj.ConfigureServices
{
	public class AutoMapperManagementConfigure
	{
		public static void Configure(IServiceCollection services)
		{
			services.AddAutoMapper(typeof(Program));
		}
	}
}
