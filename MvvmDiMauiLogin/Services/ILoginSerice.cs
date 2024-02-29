using MvvmDiMauiLogin.Models;

namespace MvvmDiMauiLogin.Services
{
  public interface ILoginService
  {
    bool        Login(User user);
    void        Logout();
    bool        IsLoggedIn();
    IPageAccess PageAccess { get; set; }

    event EventHandler<bool> ConnectionChanged;

  }
}
