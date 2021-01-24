using System;
using TimerWpfApp.ViewModels;

namespace TimerWpfApp.Models
{
    public class TimerTab : Tab
    {
        public DateTabViewModel DateTabViewModel { get; }
        public TimerTab()
        {
            Name = DateTime.Now.ToString("HH:mm:ss");
            DateTabViewModel = new DateTabViewModel();
        }
    }
}
