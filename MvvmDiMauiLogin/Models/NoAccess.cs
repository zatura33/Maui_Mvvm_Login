namespace MvvmDiMauiLogin.Models
{
  public class NoAccess: IPageAccess
  {
    public bool HasAccess(string routePath)
    {
      return false;
    }
  }
}
