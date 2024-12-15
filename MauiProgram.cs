using Microsoft.Extensions.Logging;

namespace deneme
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });
            string connectionString = "Server=DESKTOP-108VSJA;Database=NORTHWIND;User Id=sa;Password=sapass;Trusted_Connection=True;";
            builder.Services.AddSingleton<DataService>(s => new DataService(connectionString));

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
