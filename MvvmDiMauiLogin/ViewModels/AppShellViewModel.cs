﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using MvvmDiMauiLogin.Resources.Constant;
using MvvmDiMauiLogin.Service;
using MvvmDiMauiLogin.Services;

namespace MvvmDiMauiLogin.ViewModels
{
  public class AppShellViewModel : INotifyPropertyChanged
  {
    private ILoginService LoginService;
    private bool          _isConnected;
    private bool          _hasClientAccess;
    private bool          _hasEmployeAccess;


    public bool          IsConnected
    {
      get => _isConnected;
      set
      {
        _isConnected    = value;
        HasClientAccess = _isConnected;
        HasEmployeAccess= _isConnected;
        RaisePropertyChanged();
      } }

    public bool HasClientAccess
    {
      get => _hasClientAccess;
      set
      {
        _hasClientAccess = value && LoginService.PageAccess.HasAccess(Constants.ClientAcessRightSuffix);
        RaisePropertyChanged();
      }
    }

    public bool HasEmployeAccess
    {
      get => _hasEmployeAccess;
      set
      {
        _hasEmployeAccess = value && LoginService.PageAccess.HasAccess(Constants.EmployeAcessRightSuffix);
        RaisePropertyChanged();
      }
    }

    public AppShellViewModel()
    {
      LoginService                   =  ServiceHelper.GetService<ILoginService>();
      LoginService.ConnectionChanged += ConnectionChanged;
    }

    ~AppShellViewModel()
    {
      LoginService.ConnectionChanged -= ConnectionChanged;
    }

    private void ConnectionChanged(object sender, bool isConnected)
    {
      IsConnected = isConnected;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
      if (EqualityComparer<T>.Default.Equals(field, value)) return false;
      field = value;
      RaisePropertyChanged(propertyName);
      return true;
    }
  }
}