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
        public ObservableCollection<ITab> Tabs { get; }
        private AddTabModel addTabUnit { get; }
        private int selectedTabIndex = 0;
        private readonly ObservableCollection<ITab> tabs;
        public TabViewModel()
        {
            addTabUnit = new AddTabModel();
            addTabUnit.AddRequested += AddTab;

            tabs = new ObservableCollection<ITab>();
            tabs.CollectionChanged += Tabs_CollectionChanged;
            Tabs = tabs;

            Tabs.Add(new TimerTab());
            Tabs.Add(addTabUnit);
        }
        private void AddTab(object sender, EventArgs e)
        {
            Tabs.Insert(Tabs.Count - 1, new TimerTab());
            selectedTabIndex = Tabs.Count - 2;
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
            Tabs.Remove((ITab)sender);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPrChanged(string s)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(s));
        }
    }
}
