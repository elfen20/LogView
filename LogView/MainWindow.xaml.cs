using Cave.Logging;
using System;
using System.Drawing;
using System.Windows;

namespace LogView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            logItems.Level = LogLevel.Debug;
            Logger.LogInfo("App", "application started");
            logItems.GenerateFakeLogMessages(20);
        }
    }
}
