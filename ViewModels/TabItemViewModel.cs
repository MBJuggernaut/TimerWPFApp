using Microsoft.Xaml.Behaviors.Core;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TimerWpfApp.Models;

namespace TimerWpfApp.ViewModels
{
    public class TabItemViewModel : INotifyPropertyChanged
    {
        private readonly TimerSpanModel timer;
        public bool IsVisibleStart
        {
            get => !timer.IsTimerOn;

        }
        public bool IsVisiblePauseAndReset
        {
            get => timer.IsTimerOn;
        }
        public bool IsPauseButtonPressed
        {
            get => !timer.IsTimerTicking;
        }
        public string PauseButtonHeader
        {
            get
            {
                if (IsPauseButtonPressed) return "Continue";
                return "Pause";
            }
        }
        public TimeSpan Time
        {
            get => timer.Timespan;
        }
        public ICommand Start { get => new ActionCommand(() => timer.Start()); }
        public ICommand Reset { get => new ActionCommand(() => timer.Reset()); }
        public ICommand Pause
        {
            get
            {
                if (IsPauseButtonPressed) return new ActionCommand(() => timer.Start());
                return new ActionCommand(() => timer.Stop());
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public TabItemViewModel()
        {
            timer = new TimerSpanModel();
            timer.PropertyChanged += UpdateProperties;
        }

        private void UpdateProperties(object sender, EventArgs e)
        {
            OnPropertyChanged("IsVisibleStart");
            OnPropertyChanged("IsVisiblePauseAndReset");
            OnPropertyChanged("PauseButtonHeader");
            OnPropertyChanged("IsPauseButtonPressed");
            OnPropertyChanged("Time");
            OnPropertyChanged("Pause");
        }
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
