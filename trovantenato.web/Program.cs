namespace Trovantenato.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var builder = WebApplication.CreateBuilder(args);

                var startup = new Startup(builder.Configuration);

                startup.ConfigureServices(builder.Services);

                // Add services to the container.
                builder.Services.AddControllersWithViews();

                var app = builder.Build();

                startup.Configure(app, app.Environment);

                app.Run();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}