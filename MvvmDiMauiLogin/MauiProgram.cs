using Microsoft.Extensions.Logging;
using MvvmDiMauiLogin.Service;
using MvvmDiMauiLogin.Services;
using MvvmDiMauiLogin.ViewModels;
using MvvmDiMauiLogin.Views;

namespace MvvmDiMauiLogin;

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
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

    builder.Services.AddSingleton<ILoginService, LoginService>();
    builder.Services.AddSingleton<MokUsersRepository>();
    builder.Services.AddSingleton<IPopupService,PopupService>();
    builder.Services.AddSingleton<LoginPageViewModel>();
    builder.Services.AddSingleton<LoginPage>();
    builder.Services.AddSingleton<HomePageViewModel>();
    builder.Services.AddSingleton<HomePage>();
    builder.Services.AddSingleton<EmployePageViewModel>();
    builder.Services.AddSingleton<EmployePage>();
    builder.Services.AddSingleton<ClientPageViewModel>();
    builder.Services.AddSingleton<ClientPage>();
    builder.Services.AddSingleton<AppShellViewModel>();
    builder.Services.AddSingleton<AppShell>();

    // Initalize at the end to have all service in provider
    ServiceHelper.Initialize(builder.Services.BuildServiceProvider());

    return builder.Build();
	}
}
