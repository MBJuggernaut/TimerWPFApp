using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Windows.Input;

namespace TimerWpfApp.Models
{
    public class AddTabModel: Tab
    {
        public ICommand AddTabCommand { get; }
        public event EventHandler AddRequested = delegate { };
        public AddTabModel()
        {            
            AddTabCommand = new ActionCommand(() => AddRequested.Invoke(this, EventArgs.Empty));
        }
    }
}
