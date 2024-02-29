using MvvmDiMauiLogin.Models;

namespace MvvmDiMauiLogin.Services
{
  public class MokUsersRepository
  {
    private List<User> Users;

    public MokUsersRepository()
    {
      Users = new List<User>();
      Users.Add(new User(1,"Admin","1111" ,UserRightsEnum.Administrator));
      Users.Add(new User(1, "Employe", "1111", UserRightsEnum.Employe));
      Users.Add(new User(1, "Client", "1111", UserRightsEnum.Client));

    }

    public User GetUser(User user)
    {
      return Users.FirstOrDefault(x => x.Username == user.Username && x.Password == user.Password);
    }
  }
}
