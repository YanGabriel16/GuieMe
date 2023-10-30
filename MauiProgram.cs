using Microsoft.Extensions.Logging;
using Radzen;
using GuieMe.Domain.Interfaces;
using GuieMe.Infra.Services;

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
                fonts.AddFont("Verdana-Regular.ttf", "VerdanaRegular");
                fonts.AddFont("Verdana-Italic.ttf", "VerdanaItalic");
                fonts.AddFont("Verdana-Bold.ttf", "VerdanaBold");
                fonts.AddFont("Verdana-BoldItalic.ttf", "VerdanaBoldItalic");
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
        builder.Services.AddScoped<IPdfService, PdfService>();
        builder.Services.AddBlazorWebViewDeveloperTools();//TODO: Retirar 

        builder.Services.AddScoped<DialogService>();
        builder.Services.AddScoped<NotificationService>();
        builder.Services.AddScoped<TooltipService>();
        builder.Services.AddScoped<ContextMenuService>();

        return builder.Build();
	}
}
