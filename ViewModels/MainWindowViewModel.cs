using Microsoft.Xaml.Behaviors.Core;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;
using TimerWpfApp.Models;

namespace TimerWpfApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private int selectedTabIndex = 0;
        private readonly ObservableCollection<ITab> tabs;
        private readonly AddTabModel addTabUnit;

        public ICommand AddTabCommand { get => new ActionCommand(() => AddTab()); }
        public int SelectedTabIndex
        {
            get { return selectedTabIndex; }
            set
            {
                SetProperty(ref selectedTabIndex, value);
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
                if (Tabs.Count >= 2) return true;
                else return false;
            }
        }
        public ObservableCollection<ITab> Tabs { get; }

        public MainWindowViewModel()
        {
            addTabUnit = new AddTabModel();

            tabs = new ObservableCollection<ITab>();
            tabs.CollectionChanged += Tabs_CollectionChanged;
            Tabs = tabs;

            Tabs.Add(new TimerTabModel());
            Tabs.Add(addTabUnit);
        }
        private void AddTab()
        {
            if (SelectedTabIndex == Tabs.Count - 1 && TabsCanBeAdded)
            {
                Tabs.Insert(Tabs.Count - 1, new TimerTabModel());
                SelectedTabIndex = Tabs.Count - 2;

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


                if (!Tabs.Contains(addTabUnit) && TabsCanBeAdded)
                {
                    Tabs.Add(addTabUnit);
                }

                if (SelectedTabIndex == Tabs.Count - 1)
                    SelectedTabIndex--;
            }
        }
    }
}
