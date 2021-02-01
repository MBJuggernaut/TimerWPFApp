using System;
using TimerWpfApp.ViewModels;

namespace TimerWpfApp.Models
{
    public class TimerTabModel : Tab
    {
        public TabItemViewModel TabItemViewModel { get; }
        public TimerTabModel()
        {
            Name = DateTime.Now.ToString("HH:mm:ss");
            TabItemViewModel = new TabItemViewModel();
        }
    }
}
