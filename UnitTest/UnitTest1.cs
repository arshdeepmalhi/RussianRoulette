using RussianRoulette;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        

        [TestMethod]
        public void LosingTest()
        {
            GameLogic.Loses = 1;
            GameLogic.Lose();

            Assert.AreEqual(2, GameLogic.Loses);
        }
        [TestMethod]
        public void WinningTest()
        {
            GameLogic.Wins = 1;
            GameLogic.Win();

            Assert.AreEqual(2, GameLogic.Wins);
        }
        [TestMethod]
        public void TestNoOfShotsFired()
        {
            GameLogic gp = new GameLogic();
            gp.GunLoad();
            gp.GunSpin();

            int TotalShotsFired = 0;

            while (true)
            {
                TotalShotsFired++;
                if (gp.IsShotFired())
                {
                    break;
                }
            }

            bool ResultOfAssertion = TotalShotsFired <= 6 && TotalShotsFired > 0;

            Assert.IsTrue(ResultOfAssertion);
        }
    }
}
