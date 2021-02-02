using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;
using Prism.Ioc;
using System.Windows;
using TimerWpfApp.Views;

namespace TimerWpfApp
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }
        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }
    }

}

