using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.Input;
using MvvmDiMauiLogin.Models;
using MvvmDiMauiLogin.Service;
using MvvmDiMauiLogin.Services;

namespace MvvmDiMauiLogin.ViewModels
{
  public class LoginPageViewModel : BaseViewModel
    {
    private const string                     Welcome = "Welcome";
    private ILoginService                    loginService;
    private IPopupService                    popupService;
    private string                           _userName;
    private string                           _password;
    private string                           _welcomeMessage;
    private bool                             _connected;

    public bool NotConnected => !Connected  ;

    public bool Connected
    {
      get => _connected;
      set
      {
        _connected = value;
        RaisePropertyChanged();
        RaisePropertyChanged(nameof(NotConnected));
      }
    }

    public string WelcomeMessage
    {
      get => _welcomeMessage;
      set
      {
        _welcomeMessage = value;
        RaisePropertyChanged();
      }
    }

    public string Username
    {
      get => _userName;
      set
      {
        _userName = value;
        RaisePropertyChanged();
      }
    }

    public string Password
    {
      get => _password;
      set
      {
        _password = value;
        RaisePropertyChanged();
      }
    }

    public LoginPageViewModel( ILoginService loginService,IPopupService popupService)
    {
      this.loginService = loginService ?? throw new ArgumentNullException(nameof(loginService));
      this.popupService = popupService ?? throw new ArgumentNullException(nameof(popupService));

    }

    private ICommand _loginCommand;

    public ICommand LoginCommand =>
      _loginCommand ??= _loginCommand = new RelayCommand<string>(ExecuteLoginCommand);

    private void ExecuteLoginCommand(string message)
    {
      if (Shell.Current != null)
      {
        if (loginService.Login(new User(Username.Trim(), Password.Trim())))
        {
          Connected      = loginService.IsLoggedIn();
          WelcomeMessage = $"{Welcome} {Username}";
        }
        else
        {
          Connected = loginService.IsLoggedIn();
          popupService.ShowPopup("Bad username or password");
        }
      }
    }


    private ICommand _logoutCommand;

    public ICommand LogoutCommand =>
      _logoutCommand ??= _logoutCommand = new RelayCommand<string>(ExecuteLogoutCommand);

    private void ExecuteLogoutCommand(string message)
    {
      loginService.Logout();
      Connected = loginService.IsLoggedIn();
      Username  = string.Empty;
      Password = string.Empty;
    }

  }
}
