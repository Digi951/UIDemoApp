using DemoApp.WPF.MVVM.View;
using DemoApp.WPF;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DemoApp.WPF;
/// <summary>
///     Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected void ApplicationStart(object sender, StartupEventArgs e)
    {
        var loginView = new LoginView();
        loginView.Show();
        loginView.IsVisibleChanged += (s, ev) =>
        {
            if (loginView.IsVisible == false && loginView.IsLoaded)
            {
                var mainView = new MainView();
                mainView.Show();
                loginView.Close();
            }
        };
    }
}
