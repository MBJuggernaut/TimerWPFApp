using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using TimerWpfApp.Models;

namespace TimerWpfApp.ViewModels
{
    public class TabViewModel : INotifyPropertyChanged
    {

        private ICollection<ITab> tabs;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICollection<ITab> Tabs
        {
            get
            {
                return tabs;
            }
            set
            {

            }
        }

        public TabViewModel()
        {
            tabs = new ObservableCollection<ITab>
            {
                new DateTab()
            };
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
