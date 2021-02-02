using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Timers;

namespace TimerWpfApp.Models
{
    public class TimerSpanModel : INotifyPropertyChanged
    {
        private readonly Timer timer;
        private TimeSpan timeSpan;        
        private int passedTime = 0;
        private bool isTimerTicking;
        private bool isTimerStarted;

        public event PropertyChangedEventHandler PropertyChanged;
        public TimeSpan Timespan
        {
            get => timeSpan;
            set
            {
                timeSpan = value;
                OnPropertyChanged();
            }
        }        
        public bool IsTimerTicking
        {
            get => isTimerTicking;
            set
            {
                isTimerTicking = value;
                OnPropertyChanged();
            }
        }
        public bool IsTimerOn
        {
            get => isTimerStarted;
            set
            {
                isTimerStarted = value;
                OnPropertyChanged();
            }
        }

        public TimerSpanModel()
        {
            timer = new Timer(1000);
            timer.Elapsed += Timer_Elapsed;
            Timespan = TimeSpan.FromSeconds(passedTime);
        }

        public void Start()
        {
            timer.Start();
            IsTimerTicking = true;
            IsTimerOn = true;
        }
        public void Stop()
        {
            timer.Stop();
            IsTimerTicking = false;
        }
        public void Reset()
        {
            passedTime = 0;
            Timespan = TimeSpan.FromSeconds(passedTime);
            IsTimerOn = false;
        }
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            passedTime++;
            Timespan = TimeSpan.FromSeconds(passedTime);
        }
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
