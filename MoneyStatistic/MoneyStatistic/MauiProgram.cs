using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoneyStatistic.Database.Service;
using MoneyStatistic.Database.Service.Model;


namespace MoneyStatistic
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
            builder.Services.AddScoped<UserTransactionService>();

            builder.Services.AddDbContext<ApplicationDbContext>(item=>item.UseSqlServer("Server=7-166;Database=MoneyManager;Trusted_Connection=True"));

            builder.Services.AddMauiBlazorWebView();
            

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif



            return builder.Build();
        }
    }
}