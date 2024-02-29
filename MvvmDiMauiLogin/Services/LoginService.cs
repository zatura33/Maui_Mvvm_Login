using MvvmDiMauiLogin.Models;

namespace MvvmDiMauiLogin.Services
{
  public class LoginService : ILoginService
  {
    private User               User;
    private MokUsersRepository mokUsersRepository;
    public  IPageAccess        PageAccess { get; set; }
    public event EventHandler<bool>  ConnectionChanged;

    public LoginService(MokUsersRepository mokUsersRepository)
    {
      this.mokUsersRepository = mokUsersRepository ?? throw new ArgumentNullException(nameof(mokUsersRepository));
    }

    public void Logout()
    {
      User = null;
      SetPageAccess(UserRightsEnum.None);
      RaiseConnectionChange();
    }

    public bool IsLoggedIn()
    {
      return User != null;
    }

    private void RaiseConnectionChange()
    {
      if (ConnectionChanged != null)
      {
        ConnectionChanged.Invoke(this, IsLoggedIn());
      }
    }
    public bool Login(User user)
    {
        User = mokUsersRepository.GetUser(user);
        if (User != null)
        {
          SetPageAccess(User.UserRightsEnum);
        }
        RaiseConnectionChange();

      return User != null;
    }

    public void SetPageAccess(UserRightsEnum userRightsEnum)
    {
      if (userRightsEnum == UserRightsEnum.Administrator)
      {
        PageAccess = new AdminAccess();
        return;
      }
      else if (userRightsEnum == UserRightsEnum.Employe)
      {
        PageAccess = new EmployeAccess();
        return;

      }
      else if (userRightsEnum == UserRightsEnum.Client)
      {
        PageAccess = new ClientAccess(); 
        return;

      }

      PageAccess = new NoAccess();
    }

  }

}
