using MvvmDiMauiLogin.Service;

namespace MvvmDiMauiLogin;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
    MainPage = ServiceHelper.GetService<AppShell>();
  }
}
