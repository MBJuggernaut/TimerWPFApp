using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TimerWpfApp.Models;

namespace TimerWpfApp.ViewModels
{
    public class TabControlViewModel : INotifyPropertyChanged
    {
        public int SelectedTabIndex
        {
            get { return selectedTabIndex; }
            set
            {
                if (selectedTabIndex != value)
                {
                    selectedTabIndex = value;
                    OnPropertyChanged("SelectedTabIndex");
                }
            }
        }
        private bool TabsCanBeAdded
        {
            get
            {
                if (Tabs.Count < 11) return true;
                else return false;
            }
        }
        private bool TabsCanBeDeleted
        {
            get
            {
                if (Tabs.Count >=2) return true;
                else return false;
            }
        }
        public ObservableCollection<ITab> Tabs { get; }
        private AddTabModel AddTabUnit { get; }
        private int selectedTabIndex = 0;
        private readonly ObservableCollection<ITab> tabs;
        public TabControlViewModel()
        {
            AddTabUnit = new AddTabModel();
            AddTabUnit.AddRequested += OnTabAddRequested;

            tabs = new ObservableCollection<ITab>();
            tabs.CollectionChanged += Tabs_CollectionChanged;
            Tabs = tabs;

            Tabs.Add(new TimerTabModel());
            Tabs.Add(AddTabUnit);
        }
        private void OnTabAddRequested(object sender, EventArgs e)
        {
            if (TabsCanBeAdded)
            {
                Tabs.Insert(Tabs.Count - 1, new TimerTabModel());
                selectedTabIndex = Tabs.Count - 2;

                if (!TabsCanBeAdded)
                {                  
                    Tabs.RemoveAt(Tabs.Count - 1);
                }
            }
        }
        private void Tabs_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            ITab tab;
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    tab = (ITab)e.NewItems[0];
                    tab.CloseRequested += OnTabCloseRequested;
                    break;

                case NotifyCollectionChangedAction.Remove:
                    tab = (ITab)e.OldItems[0];
                    tab.CloseRequested -= OnTabCloseRequested;
                    break;
            }
        }
        private void OnTabCloseRequested(object sender, EventArgs e)
        {
            if (TabsCanBeDeleted)
            {
                Tabs.Remove((ITab)sender);
                if (!Tabs.Contains(AddTabUnit)&&TabsCanBeAdded)
                {
                    Tabs.Add(AddTabUnit);                   
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
