namespace MvvmDiMauiLogin.Models
{
  public class User
  {
    public int    Id       { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    public UserRightsEnum UserRightsEnum { get; set; }

    public User(int id, string username, string password, UserRightsEnum userRightsEnum)
    {
      this.Id        = id;
      Username       = username;
      Password       = password;
      UserRightsEnum = userRightsEnum;  
    }

    public User(string username, string password)
    {
      Username = username;
      Password = password;
    }


  }
}
