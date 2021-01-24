using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using TimerWpfApp.Models;

namespace TimerWpfApp.ViewModels
{
    public class TabViewModel
    {
        public ICommand AddTabCommand { get; }
        public int SelectedIndex { get; set; }
        public ObservableCollection<ITab> Tabs { get; }
        private readonly ObservableCollection<ITab> tabs;

        public TabControl tabControl;

        public TabViewModel()
        {

            AddTabCommand = new RelayCommand(() => AddTab(), true);
            tabs = new ObservableCollection<ITab>();
            tabs.CollectionChanged += Tabs_CollectionChanged;
            Tabs = tabs;
            Tabs.Add(new DateTab());
        }

        private void AddTab()
        {
            Tabs.Add(new DateTab());
        }

        private void Tabs_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            ITab tab;
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    tab = (ITab)e.NewItems[0];
                    tab.CloseRequested += OnTabCloseRequested;
                    SelectedIndex = tabs.Count-1;
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
    }
}
