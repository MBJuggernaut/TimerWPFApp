using System;
using System.Windows.Input;

namespace TimerWpfApp.Models
{
    public interface ITab
    {        
        bool CanBeDeleted { get; set; }
        string Name { get; set; }
        ICommand CloseCommand { get; }
        event EventHandler CloseRequested;
    }
}
