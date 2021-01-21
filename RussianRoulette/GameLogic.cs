using System;
using System.Media;
using System.Windows;

namespace RussianRoulette
{
    public class GameLogic
    {
        public static int Wins = 0;
        public static int Loses = 0;
        public int NoOfShots = 6;
        public bool IsFarAway = true;
        public int InAirChoices = 2;

        private int BulletPosition;
        private int StrikerCurrentPosition;
        private Random RAND;
        private int GetRandomNumber()
        {
            RAND = new Random();
            return RAND.Next(1, 7);
        }

        // Play Fire Sound
        private void PlayFireSound()
        {
            SoundPlayer soundPlayer = new SoundPlayer("Resources\\sound\\fire.wav");
            soundPlayer.Load();
            soundPlayer.Play();
        }

      
      // Play Gun empty sound
        private void PlayEmptyGunSound()
        {
            SoundPlayer player = new SoundPlayer("Resources\\sound\\empty.wav");
            player.Load();
            player.Play();
        }

        // Check if gun is loaded
        public bool IsGunLoaded()
        {
            if (BulletPosition == 0)
            {
               MessageBox.Show("Load bullet in the gun.","info",MessageBoxButton.OK,MessageBoxImage.Information);
                return false;
            }
            else if (StrikerCurrentPosition == 0)
            {
                MessageBox.Show("Please spin the chamber.", "info", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else
            {
                return true;
            }
        }
        // mehtod to load gun
        public void GunLoad()
        {
            BulletPosition = GetRandomNumber();
        }

        // method to spin gun
        public void GunSpin()
        {
            StrikerCurrentPosition = GetRandomNumber();
        }

        public static void Win()
        {
            Wins++;
            _ = MessageBox.Show("You Won the Game! \n Your Wins: " + Wins, "info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public static void Lose()
        {
            Loses++;
            _ = MessageBox.Show("You Lost the Game! \n Your Loses: " + Loses, "info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

  
        // method to check if shot is fired
        // it returns true if shot is fired and decreasers no of shots
        public bool IsShotFired()
        {
            NoOfShots--;
            if(IsFarAway)
            {
                InAirChoices--;
            }
           
            if (BulletPosition == StrikerCurrentPosition)
            {
                PlayFireSound();
                return true;
            }
            else
            {
                StrikerCurrentPosition = StrikerCurrentPosition == 6 ? 1 : ++StrikerCurrentPosition;
                PlayEmptyGunSound();
                return false;
            }
        }
    }
}
