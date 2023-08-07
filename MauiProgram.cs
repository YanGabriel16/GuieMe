using Microsoft.Extensions.Logging;
using GuieMe.Services;
using Radzen;
using GuieMe.Interfaces;

namespace GuieMe;

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

		builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

        builder.Services.AddScoped<IDataStorageService, DataStorageService>();
        builder.Services.AddScoped<ILocalService, LocalService>();
        builder.Services.AddScoped<IObjetivoService, ObjetivoService>();
        builder.Services.AddScoped<IUsuarioService, UsuarioService>();
		builder.Services.AddScoped<IHelperService, HelperService>();
        builder.Services.AddBlazorWebViewDeveloperTools();

        builder.Services.AddScoped<DialogService>();
        builder.Services.AddScoped<NotificationService>();
        builder.Services.AddScoped<TooltipService>();
        builder.Services.AddScoped<ContextMenuService>();

        return builder.Build();
	}
}
