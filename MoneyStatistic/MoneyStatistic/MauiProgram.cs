using Blazorise;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.Extensions.Logging;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using MudBlazor.Services;
using MoneyStatistic.Database.SQLiteDB;


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

            builder.Services.AddSingleton<userDB>();

            builder.Services.AddSweetAlert2();
            builder.Services.AddMudServices();
            builder.Services.AddBlazorise(options =>
            {
                options.Immediate = true;
            })
            .AddBootstrapProviders()
            .AddFontAwesomeIcons();
            
            builder.Services.AddMauiBlazorWebView();
            
            

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif



            return builder.Build();
        }
    }
}