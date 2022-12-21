using DemoApp.WPF.MVVM.Model;
using DemoApp.WPF.Repositories;
using System.Threading;
using System.Windows;

namespace DemoApp.WPF.MVVM.ViewModel;

public class MainViewModel : ViewModelBase
{
	private UserAccountModel _currentUserAccount;
    private IUserRepository _userRepository;

    public UserAccountModel CurrentUserAccount
	{
		get { return _currentUserAccount; }
		set 
		{ 
			_currentUserAccount = value; 
			OnPropertyChanged(nameof(CurrentUserAccount));
		}
	}

	private void LoadCurrentUserData()
	{
		var user = _userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);

		if (user is not null)
		{
			CurrentUserAccount.Username = user.Username;
			CurrentUserAccount.DisplayName = $"Welcome {user.Name} {user.LastName} ;)";
            CurrentUserAccount.ProfilePicture = null;			
		}
		else
		{
			CurrentUserAccount.DisplayName = "Invalid user. not logged in";			
		}
    }

	public MainViewModel()
	{
		var user = new UserAccountModel();
		CurrentUserAccount = new();
		LoadCurrentUserData();		
	}
}
