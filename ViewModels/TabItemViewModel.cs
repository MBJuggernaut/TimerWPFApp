using Microsoft.Xaml.Behaviors.Core;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TimerWpfApp.Models;

namespace TimerWpfApp.ViewModels
{
    public class TabItemViewModel: INotifyPropertyChanged
    {
        private bool IsVisible = true;
        public bool IsVisibleStart
        {
            get
            {
                return IsVisible;
            }
            set
            {
                IsVisible = value;
                OnPropertyChanged("IsVisibleStart");
            }
        }
        public bool IsVisiblePauseAndReset
        {
            get
            {
                return !IsVisible;
            }
            set
            {
                IsVisible = !value;
                OnPropertyChanged("IsVisiblePauseAndReset");
            }
        }

        private bool isPauseButtonPressed;
        public bool IsPauseButtonPressed
        {
            get => isPauseButtonPressed;
            set
            {
                isPauseButtonPressed = value;
                OnPropertyChanged();
            }
        }

        private string pauseButtonHeader;
        public string PauseButtonHeader
        {
            get => pauseButtonHeader;
            set
            {
                pauseButtonHeader = value;
                OnPropertyChanged();
            }
        }

        private TimeSpan time;
        public TimeSpan Time
        {
            get => time;
            set
            {
                time = value;
                OnPropertyChanged();
            }
        }

        public ICommand Start { get; }
        public ICommand Reset { get; }

        private ICommand pause;
        public ICommand Pause
        {
            get => pause;
            set
            {
                pause = value;
                OnPropertyChanged("Pause");
            }
        }

        private readonly TimerSpanModel timer;

        public TabItemViewModel()
        {
            timer = new TimerSpanModel();

            Start = new ActionCommand(() => StartTimer());

            Reset = new ActionCommand(() => ResetTimer());

            timer.TimerClicked += UpdateFields;
        }

        private void UpdateFields(object sender, EventArgs e)
        {
            Time = timer.Timespan;
        }
        private void StartTimer()
        {
            timer.Start();
            PauseButtonHeader = "Pause";
            Pause = new ActionCommand(() => PauseTimer());
            IsVisibleStart = false;
            IsVisiblePauseAndReset = true;
            IsPauseButtonPressed = false;
        }
        private void PauseTimer()
        {
            timer.Stop();
            PauseButtonHeader = "Continue";

            Pause = new ActionCommand(() => StartTimer());
            IsPauseButtonPressed = true;
        }
        private void ResetTimer()
        {
            timer.Reset();
            Time = timer.Timespan;
            IsVisibleStart = true;
            IsVisiblePauseAndReset = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
