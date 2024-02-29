
namespace MvvmDiMauiLogin.Resources.Constant
{
  public class Constants
  {
    // Routes data is mok here it is suppose to comes from a route/role repository (DB) in a real project
    public const string EmployeAcessRightSuffix = "_EmployeRoute";
    public const string EmployePageRoute   = $"EmployePage{EmployeAcessRightSuffix}";
    public const string ClientAcessRightSuffix  = "_ClientRoute";
    public const string ClientPageRoute    = $"ClientPage{ClientAcessRightSuffix}{EmployeAcessRightSuffix}";
  }
}
