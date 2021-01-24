using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TimerWpfApp.Models;

namespace TimerWpfApp.ViewModels
{
    public class DateTabViewModel: INotifyPropertyChanged
    {
        private TimeSpan time;
        public TimeSpan Time
        {
            get => time;
            set
            {
                time = value;
                OnPropertyChanged("Time");
            }
        }
        public ICommand Start { get; }
        public TimerSpan timer;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public DateTabViewModel()
        {
            timer = new TimerSpan();
            Start = new ActionCommand(() => StartTimer());
            timer.TimerClicked += UpdateFields;
        }

        private void UpdateFields(object sender, EventArgs e)
        {
            Time = timer.Timespan;
        }

        private void StartTimer()
        {
            timer.Start();
        }
    }
}
