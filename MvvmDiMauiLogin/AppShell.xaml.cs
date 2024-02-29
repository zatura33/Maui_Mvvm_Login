using MvvmDiMauiLogin.Service;
using MvvmDiMauiLogin.Services;
using MvvmDiMauiLogin.ViewModels;
using MvvmDiMauiLogin.Views;

namespace MvvmDiMauiLogin;

public partial class AppShell : Shell
{
  private ILoginService LoginService;
  private IPopupService PopupService;

  public AppShell(ILoginService loginService, IPopupService popupService,AppShellViewModel appShellViewModel)
  {
    InitializeComponent();
    LoginService   = loginService ?? throw new ArgumentNullException(nameof(loginService));
    PopupService   = popupService ?? throw new ArgumentNullException(nameof(popupService));
  }

  protected override void OnNavigating(ShellNavigatingEventArgs args)
  {
    base.OnNavigating(args);

    string target = args.Target.Location.ToString();
    if (target.Contains(nameof(LoginPage)) ||
        target.Contains(nameof(HomePage))  ||
        IsBackNavigationCheck(args)              ||
        RouteHasPageAccess(target))
    {
      return;
    }
    else
    {
      PopupService.ShowPopup("You dont have rights to go to this page");
      args.Cancel();
      Shell.Current.GoToAsync(nameof(LoginPage));
    }
  }

  private bool RouteHasPageAccess(string target)
  {
    return LoginService.PageAccess != null &&
           LoginService.PageAccess.HasAccess(target);
  }

  private bool IsBackNavigationCheck(ShellNavigatingEventArgs args)
  {
    return args.Source == ShellNavigationSource.Pop;
  }
}