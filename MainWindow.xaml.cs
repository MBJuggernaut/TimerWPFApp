using GalaSoft.MvvmLight.Command;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TimerWpfApp.Models;

namespace TimerWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ICommand NewTabCommand { get; }

        public ICollection<ITab> Tabs { get; }
        
        public MainWindow()
        {
            InitializeComponent();
            NewTabCommand = new RelayCommand(() => NewTab());
            Tabs = new ObservableCollection<ITab>
            {
                new DateTab()
            };
        }


        private void NewTab()
        {
            //MessageBox.Show("!");
        }

        //private void AddTab_Click(object sender, MouseButtonEventArgs e)
        //{
        //    AddNewTab();
        //}

        //private void AddNewTab()
        //{
        //    var currentTime = DateTime.Now.ToString("HH:mm");
        //    int index = TimerTabControl.Items.Count;
        //    TimerTabControl.Items.Insert(index - 1, new TabItem
        //    {
        //        Header = new TextBlock { Text = $"{index} {currentTime}" }, // установка заголовка вкладки
        //    });

        //    if (index == 10)
        //    {
        //        AddTab.Visibility = Visibility.Hidden;
        //    }
        //}
    }
}

