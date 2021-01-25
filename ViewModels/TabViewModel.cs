using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using TimerWpfApp.Models;

namespace TimerWpfApp.ViewModels
{
    public class TabViewModel : INotifyPropertyChanged
    {
        public int SelectedTabIndex
        {
            get { return selectedTabIndex; }
            set
            {
                if (selectedTabIndex != value)
                {
                    selectedTabIndex = value;
                    OnPrChanged("SelectedTabIndex");
                }
            }
        }
        private bool TabsCanBeAdded = true;
        private bool TabsCanBeDeleted = true;
        public ObservableCollection<ITab> Tabs { get; }
        private AddTabModel AddTabUnit { get; }
        private int selectedTabIndex = 0;
        private readonly ObservableCollection<ITab> tabs;
        public TabViewModel()
        {
            AddTabUnit = new AddTabModel();
            AddTabUnit.AddRequested += AddTab;

            tabs = new ObservableCollection<ITab>();
            tabs.CollectionChanged += Tabs_CollectionChanged;
            Tabs = tabs;

            Tabs.Add(new TimerTabModel());
            Tabs.Add(AddTabUnit);
        }
        private void AddTab(object sender, EventArgs e)
        {
            if (TabsCanBeAdded)
            {
                Tabs.Insert(Tabs.Count - 1, new TimerTabModel());
                selectedTabIndex = Tabs.Count - 2;

                if (Tabs.Count > 10)
                {
                    TabsCanBeAdded = false;
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
                if (!TabsCanBeAdded)
                {
                    Tabs.Add(AddTabUnit);
                    TabsCanBeAdded = true;
                }

            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPrChanged(string s)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(s));
        }
    }
}
