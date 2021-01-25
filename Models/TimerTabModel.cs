﻿using System;
using TimerWpfApp.ViewModels;

namespace TimerWpfApp.Models
{
    public class TimerTabModel : Tab
    {
        public TimerTabViewModel DateTabViewModel { get; }
        public TimerTabModel()
        {
            Name = DateTime.Now.ToString("HH:mm:ss");
            DateTabViewModel = new TimerTabViewModel();
        }
    }
}