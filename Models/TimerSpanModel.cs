using System;
using System.Timers;

namespace TimerWpfApp.Models
{
    public class TimerSpanModel
    {
        private readonly Timer timer;
        public TimeSpan Timespan;
        public int passedtime = 0;
        public event EventHandler TimerClicked = delegate { };

        public TimerSpanModel()
        {
            timer = new Timer(1000);
            timer.Elapsed += Timer_Elapsed;
            Timespan = TimeSpan.FromSeconds(passedtime);            
        }

        public void Start()
        {
            timer.Start();
        }
        public void Stop()
        {
            timer.Stop();
        }
        public void Reset()
        {
            passedtime = 0;
            Timespan = TimeSpan.FromSeconds(passedtime);
        }
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            passedtime++;
            Timespan = TimeSpan.FromSeconds(passedtime);
            TimerClicked.Invoke(this, EventArgs.Empty);
        }
    }
}
