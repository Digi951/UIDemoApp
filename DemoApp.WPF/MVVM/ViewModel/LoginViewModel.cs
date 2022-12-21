using DemoApp.WPF.MVVM.Model;
using DemoApp.WPF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DemoApp.WPF.MVVM.ViewModel;
public class LoginViewModel : ViewModelBase
{
    private String _username;
    private SecureString _password;
    private String _errorMessage;
    private Boolean _isViewVisible = true;

    private IUserRepository _userRepository;

    public string Username 
    {
        get
        {
            return _username;
        }
        set
        {
            _username = value;
            OnPropertyChanged(nameof(Username));
        }
    }

    public SecureString Password
    {
        get
        {
            return _password;
        }
        set
        {
            _password = value;
            OnPropertyChanged(nameof(Password));
        }
    }

    public string ErrorMessage 
    { 
        get
        {
            return _errorMessage;
        }
        set
        {
            _errorMessage = value;
            OnPropertyChanged(nameof(ErrorMessage));
        }
    }

    public bool IsViewVisible 
    { 
        get
        {
            return _isViewVisible;
        }
        set
        {
            _isViewVisible = value;
            OnPropertyChanged(nameof(IsViewVisible));
        }
    }

    // Commands
    public ICommand LoginCommand { get; }
    public ICommand RecoverPasswordCommand { get; }
    public ICommand ShowPasswordCommand { get; }
    public ICommand RememberPasswordCommand { get; }

    public LoginViewModel()
    {
        _userRepository = new UserRepository();
        LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanmExecuteLoginCommand);
        RecoverPasswordCommand = new ViewModelCommand(p => ExecuteRecoverPassCommand("", ""));
    }        

    private bool CanmExecuteLoginCommand(object obj)
    {
        Boolean validData;

        if (String.IsNullOrWhiteSpace(Username) || Username.Length < 3
            || Password is null || Password.Length < 3) 
        {
            validData = false;
        }
        else
        {
            validData = true;
        }

        return validData;
    }

    private void ExecuteLoginCommand(object obj)
    {
        var isValidUser = _userRepository.AuthenticateUser(new NetworkCredential(Username, Password));

        if (isValidUser) 
        {
            Thread.CurrentPrincipal = new GenericPrincipal(
                new GenericIdentity(Username), null);
            IsViewVisible = false;
        }
        else
        {
            ErrorMessage = "* Invalid username or password";
        }
    }

    private void ExecuteRecoverPassCommand(String username, String email)
    {
        throw new NotImplementedException();
    }
}
