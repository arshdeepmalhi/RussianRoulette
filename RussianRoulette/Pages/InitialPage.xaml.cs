using System.Windows;
using System.Windows.Controls;

namespace RussianRoulette.Pages
{
 
    public partial class InitialPage : Page
    {
        // objects  creation
        private readonly Frame df;
        private readonly GameLogic gp;

        // ctor
        public InitialPage(Frame DF)
        {
            InitializeComponent();
            this.df = DF;
            gp = new GameLogic();
            LoseScore.Text = GameLogic.Loses.ToString();
            WinScore.Text = GameLogic.Wins.ToString();
        }

        private void SpinButton_Click(object sender, RoutedEventArgs e)
        {
            gp.GunSpin();
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            gp.GunLoad();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (gp.IsGunLoaded())
            {
                df.Navigate(new GamePage(df, gp));
            }
        }
    }
}
