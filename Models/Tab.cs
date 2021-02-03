using Microsoft.Xaml.Behaviors.Core;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace TimerWpfApp.Models
{
    public abstract class Tab : ITab, INotifyPropertyChanged
    {
        private string name;
       // private bool canBeDeleted;

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand CloseCommand { get; }
        public event EventHandler CloseRequested = delegate { };
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public bool CanBeDeleted
        {
            get;set;
        }

        public Tab()
        {
            CloseCommand = new ActionCommand(() => CloseRequested.Invoke(this, EventArgs.Empty));
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
