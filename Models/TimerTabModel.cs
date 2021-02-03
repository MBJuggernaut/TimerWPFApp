using System;
using System.ComponentModel;
using TimerWpfApp.ViewModels;

namespace TimerWpfApp.Models
{
    public class TimerTabModel : Tab, INotifyPropertyChanged
    {
        public new bool CanBeDeleted { get { return TabItemViewModel.IsVisibleStart; } set { OnPropertyChanged(); } }
        public TabItemViewModel TabItemViewModel { get; }
        public TimerTabModel(int tabsCount)
        {
            Name = $"{tabsCount}. {DateTime.Now.ToString("HH:mm:ss")}";
            TabItemViewModel = new TabItemViewModel();            
        }
    }
}
