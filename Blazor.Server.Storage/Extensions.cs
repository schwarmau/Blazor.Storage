using Microsoft.Extensions.DependencyInjection;

namespace Blazor.Server.Storage
{
	public static class Extensions
	{
		public static IServiceCollection ConfigureStorage(this IServiceCollection services)
		{
			services.AddScoped<SessionStorage>();
			services.AddScoped<LocalStorage>();
			return services;
		}
	}
}
