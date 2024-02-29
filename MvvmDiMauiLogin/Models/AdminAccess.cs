namespace MvvmDiMauiLogin.Models
{
  public class AdminAccess :IPageAccess
  {
    public bool HasAccess(string routePath)
    {
      return true;
    }
  }
}
