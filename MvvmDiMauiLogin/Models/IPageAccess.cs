namespace MvvmDiMauiLogin.Models
{
  public interface IPageAccess
  {
    public bool HasAccess(string routePath);
  }
}
