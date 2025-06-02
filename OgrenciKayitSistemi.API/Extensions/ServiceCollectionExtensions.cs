using Microsoft.EntityFrameworkCore;
using OgrenciKayitSistemi.Application.Abstractions;
using OgrenciKayitSistemi.Application.Abstractions.EfCore.UnitOfWork;
using OgrenciKayitSistemi.Persistence.EfCore.Context;
using OgrenciKayitSistemi.Persistence.EfCore.UnitOfWork;
using OgrenciKayitSistemi.Persistence.Services;


namespace OgrenciKayitSistemi.Api.Extensions
{
	public static class ServiceCollectionExtensions
	{
		private const string OgrenciKayitSistemiDbConnectionString = "OgrenciKayitSistemiDb_ConnectionString";

		public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
		{
            services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

			services.AddDbContext<OgrenciKayitDbContext>(options=> options.UseSqlServer(configuration.GetConnectionString(OgrenciKayitSistemiDbConnectionString)));
		}

		public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddScoped<IOgrenciKayitSistemiService, OgrenciKayitSistemiService>();
		}
	}
}
