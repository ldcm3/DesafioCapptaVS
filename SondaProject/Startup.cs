using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
//using SondaProject.Models;

namespace SondaProject
{
	public class Startup
	{
		//public void ConfigureServices(IServiceCollection services)
		//{
		//	services.AddDbContext<SondaContext>(opt => opt.UseInMemoryDatabase("SondaProject"));
		//	services.AddMvc();
		//}

		public void Configure(IApplicationBuilder app)
		{
			app.UseMvc();
		}
	}
}