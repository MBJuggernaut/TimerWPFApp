using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TimerWpfApp.Models
{
    public class AddTab: Tab
    {
        public ICommand AddTabCommand { get; }
        public event EventHandler AddRequested = delegate { };
        public AddTab()
        {            
            AddTabCommand = new ActionCommand(() => AddRequested.Invoke(this, EventArgs.Empty));
        }
    }
}
