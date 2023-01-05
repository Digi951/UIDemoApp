using DemoApp.WPF.MVVM.Model;
using DemoApp.WPF.Repositories;
using FontAwesome.Sharp;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace DemoApp.WPF.MVVM.ViewModel;

public class MainViewModel : ViewModelBase
{
	// Fields
	private UserAccountModel _currentUserAccount;
	private ViewModelBase _currentChildView;
	private String _caption;
	private IconChar _icon;

    private IUserRepository _userRepository;

	// Properties
    public UserAccountModel CurrentUserAccount
	{
		get { return _currentUserAccount; }
		set 
		{ 
			_currentUserAccount = value; 
			OnPropertyChanged(nameof(CurrentUserAccount));
		}
	}

    public ViewModelBase CurrentChildView 
	{ get
		{
			return _currentChildView;
		}
		set
		{
			_currentChildView = value;
			OnPropertyChanged(nameof(CurrentChildView));
		}
	}

    public string Caption 
	{ 
		get
		{
			return _caption;
		}
		set
		{
			_caption = value; 
			OnPropertyChanged(nameof(Caption));
		}
	}
    public IconChar Icon 
	{
		get
		{
			return _icon;
		}
		set
		{
			_icon = value;
			OnPropertyChanged(nameof(Icon));
		}
	}

	// Commands
	public ICommand ShowHomeViewCommand { get; }
	public ICommand ShowCustomerViewCommand { get; }

    private void LoadCurrentUserData()
	{
		var user = _userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);

		if (user is not null)
		{
			CurrentUserAccount.Username = user.Username;
			CurrentUserAccount.DisplayName = $"{user.Name} {user.LastName}";
            CurrentUserAccount.ProfilePicture = null;			
		}
		else
		{
			CurrentUserAccount.DisplayName = "Invalid user. not logged in";			
		}
    }

    private void ExecuteShowCustomerViewCommand(object obj)
    {
        CurrentChildView = new CustomerViewModel();
		Caption = "Customers";
		Icon = IconChar.UserGroup;
    }

    private void ExecuteShowHomeViewCommand(object obj)
    {
        CurrentChildView = new HomeViewModel();
        Caption = "Dashboard";
        Icon = IconChar.Home;
    }
    public MainViewModel()
    {
        _userRepository = new UserRepository();
        CurrentUserAccount = new();

        // Initialize commands
        ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
        ShowCustomerViewCommand = new ViewModelCommand(ExecuteShowCustomerViewCommand);

		// Dafault View
		ExecuteShowHomeViewCommand(null);
        LoadCurrentUserData();
    }
}
