using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using MudBlazor.Services;
using RCLCP.Interfaces;
using RCLCP.Services;

namespace AppContasPagar;

#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;
#endif

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

        #if WINDOWS
                builder.ConfigureLifecycleEvents(events =>
                {
                    events.AddWindows(wndLifeCycleBuilder =>
                    {
                        wndLifeCycleBuilder.OnWindowCreated(window =>
                        {
                            IntPtr nativeWindowHandle = WinRT.Interop.WindowNative.GetWindowHandle(window);
                            WindowId win32WindowsId = Win32Interop.GetWindowIdFromWindow(nativeWindowHandle);
                            AppWindow winuiAppWindow = AppWindow.GetFromWindowId(win32WindowsId);
                            if (winuiAppWindow.Presenter is OverlappedPresenter p)
                                p.Maximize();
                            else
                            {
                                const int width = 1200;
                                const int height = 800;
                                winuiAppWindow.MoveAndResize(new RectInt32(1920 / 2 - width / 2, 1080 / 2 - height / 2, width, height));
                            }
                        });
                    });
                });
        #endif

        builder.Services.AddMudServices();

        builder.Services.AddSingleton<IPlatformService, PlatformService>();
        builder.Services.AddSingleton<IDropbox, DropboxService>();
        builder.Services.AddSingleton<IBancoDados, BancoDadosService>();
        builder.Services.AddSingleton<IContaBancaria, ContaBancariaService>();
        builder.Services.AddSingleton<IDespesa, DespesaService>();
        builder.Services.AddSingleton<IFornecedor, FornecedorService>();
        builder.Services.AddSingleton<IPagamento, PagamentoService>();
        builder.Services.AddSingleton<IUsuario, UsuarioService>();

        return builder.Build();
	}
}
