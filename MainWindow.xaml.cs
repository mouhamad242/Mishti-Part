using System;
using System.Windows;
using System.Windows.Controls;

namespace ProjectManagementSystem
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenProjectPage(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ProjectPage());
        }
    }
}
