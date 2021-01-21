using System.Windows;
using RussianRoulette.Pages;

namespace RussianRoulette
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainForm : Window
    {
        public MainForm()
        {
            InitializeComponent();
            _ = DriverFrame.Navigate(new InitialPage(DriverFrame));
        }
    }
}
