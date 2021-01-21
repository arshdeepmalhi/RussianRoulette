using System.Windows;
using System.Windows.Controls;

namespace RussianRoulette.Pages
{
   
    public partial class GamePage : Page
    {
        // objects
        private Frame df;
        private GameLogic gp;

        // ctor
        public GamePage(Frame DF, GameLogic GP)
        {
            InitializeComponent();
            // init objects
            this.df = DF;
            this.gp = GP;
        }
      
        
        private void FireButton_Click(object sender, RoutedEventArgs e)
        {
            // check for win or lose when fire button is clicked
            if (gp.IsShotFired())
            {
                if (gp.IsFarAway)
                {
                    GameLogic.Win();
                }
                else
                {
                    GameLogic.Lose();
                }
                df.Navigate(new InitialPage(df));
            }
            else
            {
             
            }
            ShotsRemaining.Text = gp.NoOfShots.ToString();
        }

        private void HeadShoot_Click(object sender, RoutedEventArgs e)
        {
            if (HeadShoot.IsChecked == true)
            {
                gp.IsFarAway = false;
                AirShoot.IsChecked = false;
            }
        }

        private void AirShoot_Click(object sender, RoutedEventArgs e)
        {
            if (AirShoot.IsChecked == true)
            {
                gp.IsFarAway = true;
                HeadShoot.IsChecked = false;

            }
        }
    }
}
