using System;
using System.Windows.Input;

namespace TimerWpfApp.Models
{
    public interface ITab
    {
        string Name { get; set; }
        ICommand CloseCommand { get; }
        event EventHandler CloseRequested;
    }
}
