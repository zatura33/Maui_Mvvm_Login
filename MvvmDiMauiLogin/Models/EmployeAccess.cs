using MvvmDiMauiLogin.Resources.Constant;

namespace MvvmDiMauiLogin.Models
{
  public class EmployeAccess : IPageAccess
  {
    public bool HasAccess(string routePath)
    {
      return routePath.Any(x=> routePath.Contains(Constants.EmployeAcessRightSuffix));
    }
  }
}
