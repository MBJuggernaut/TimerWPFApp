using System;
using System.Windows;
using System.Windows.Controls;
using TimerWpfApp.Models;

namespace TimerWpfApp.ViewModels
{
    public class TabTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ItemTemplate { get; set; }
        public DataTemplate NewButtonTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            Type itemtype = item.GetType();
            Type ad = typeof(AddTabModel);
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
