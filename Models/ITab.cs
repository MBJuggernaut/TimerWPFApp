using System;
using System.Windows.Input;

namespace TimerWpfApp.Models
{
    public interface ITab
    {
        string Name { get; set; }
        ICommand CloseCommand { get; set; }
        event EventHandler CloseRequested;
    }
}
