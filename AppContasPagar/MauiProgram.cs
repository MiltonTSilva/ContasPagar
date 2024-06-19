using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using RCLCP.Interfaces;
using RCLCP.Services;

namespace AppContasPagar;

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

		builder.Services.AddMudServices();

		builder.Services.AddSingleton<IPlatformService, PlatformService>();
		builder.Services.AddSingleton<IBancoDados, BancoDadosService>();
		builder.Services.AddSingleton<IContaBancaria, ContaBancariaService>();

		return builder.Build();
	}
}
