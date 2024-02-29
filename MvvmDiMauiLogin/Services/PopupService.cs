namespace MvvmDiMauiLogin.Service
{
  public class PopupService : IPopupService
  {
    public void ShowPopup(string message)
    {
      Page page = Application.Current?.MainPage ?? throw new NullReferenceException();
      _ = page.DisplayAlert("Alert", message, "Ok");
    }
  }
}
