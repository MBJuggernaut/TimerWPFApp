using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace TimerWpfApp.ViewModels
{
    class ShellViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        public DelegateCommand<string> NavigateCommand { get; set; }
        public ShellViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        private void Navigate(string uri)
        {
            regionManager.RequestNavigate("ContentRegion", uri);
        }
    }
}
