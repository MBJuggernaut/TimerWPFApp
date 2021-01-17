using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TimerWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            AddNewTab();
        }

        private void AddTab_Click(object sender, MouseButtonEventArgs e)
        {
            AddNewTab();
        }

        private void AddNewTab()
        {
            var currentTime = DateTime.Now.ToString("HH:mm");
            int index = TimerTabControl.Items.Count;
            TimerTabControl.Items.Insert(index - 1, new TabItem
            {
                Header = new TextBlock { Text = $"{index} {currentTime}" }, // установка заголовка вкладки
            });

            if (index == 10)
            {
                AddTab.Visibility = Visibility.Hidden;               
            }
        }
    }
}

