namespace Trovantenato.Web.ExternalServices.Startup
{
    public static class ExternalServicesStartupExtensions
    {
        public static void AddExternalServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<AppApi.Contact.Interfaces.IAppApiProxy, AppApi.Contact.Proxy.AppApiProxy>();
            services.AddScoped<AppApi.Contact.Interfaces.IAppApiService, AppApi.Contact.AppApiService>();

            services.AddScoped<AppApi.Immigrant.Interfaces.IAppApiProxy, AppApi.Immigrant.Proxy.AppApiProxy>();
            services.AddScoped<AppApi.Immigrant.Interfaces.IAppApiService, AppApi.Immigrant.AppApiService>();
        }
    }
}
