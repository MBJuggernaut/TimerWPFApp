using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Windows.Input;

namespace TimerWpfApp.Models
{
    public abstract class Tab : ITab
    {
        public Tab()
        {
            CloseCommand = new ActionCommand(() => CloseRequested.Invoke(this, EventArgs.Empty));
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value;}
        }

        public ICommand CloseCommand { get; }

        public event EventHandler CloseRequested = delegate { };
    }
}
