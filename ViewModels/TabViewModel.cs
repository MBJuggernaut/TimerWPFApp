using GalaSoft.MvvmLight.Command;
using Microsoft.Xaml.Behaviors.Core;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;
using TimerWpfApp.Models;

namespace TimerWpfApp.ViewModels
{
    public class TabViewModel
    {
       // public ICommand AddTabCommand { get; }
        public int selectedTabIndex = 0;
       public AddTab addTab { get; }
        public int SelectedTabIndex
        {
            get
            {
                return selectedTabIndex;
            }
            set
            {
                selectedTabIndex = value;
            }
        }
        public ObservableCollection<ITab> Tabs { get; }
        private readonly ObservableCollection<ITab> tabs;

        public TabViewModel()
        {
            addTab = new AddTab();
            tabs = new ObservableCollection<ITab>();
            tabs.CollectionChanged += Tabs_CollectionChanged;
            Tabs = tabs;
            addTab.AddRequested += AddTab;
            Tabs.Add(new DateTab());
            Tabs.Add(addTab);                      
        }

        

        private void AddTab(object sender, EventArgs e)         
        {

            Tabs.Insert(Tabs.Count - 1, new DateTab());
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
    }

    public class TabTemplateSelector: DataTemplateSelector
    {
        public DataTemplate ItemTemplate { get; set; }
        public DataTemplate NewButtonTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            Type itemtype = item.GetType();
            Type ad = typeof(AddTab);
            if (itemtype.Equals(ad))
            {
                return NewButtonTemplate;
            }
            else
            {
                return ItemTemplate;
            }
        }
    }
}
