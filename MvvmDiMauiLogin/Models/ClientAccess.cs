using MvvmDiMauiLogin.Resources.Constant;

namespace MvvmDiMauiLogin.Models
{
  internal class ClientAccess : IPageAccess
  {
    public bool HasAccess(string routePath)
    {
      return routePath.Any(x => routePath.Contains(Constants.ClientAcessRightSuffix));
    }
  }
}
