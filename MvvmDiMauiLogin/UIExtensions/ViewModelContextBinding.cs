using MvvmDiMauiLogin.Service;

namespace MvvmDiMauiLogin.UIExtensions
{
  public class ViewModelContextBinding<TPropertyType> : IMarkupExtension<TPropertyType>
  {
     
      public TPropertyType ProvideValue(IServiceProvider serviceProvider)
      {

        return ServiceHelper.GetService<TPropertyType>();
      }

      object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
      {
        return ProvideValue(ServiceHelper.Services);
      }
    
  }
}
