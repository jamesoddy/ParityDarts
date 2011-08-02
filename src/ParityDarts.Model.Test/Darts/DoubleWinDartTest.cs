using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ParityDarts.Model;
using NUnit.Framework;
using ParityDarts.Contracts;

namespace ParityDarts.Model.Test
{
    [TestFixture]
    public class DoubleWinDartTest
    {
        [Test]
        public void DoubleWinDart_EqualPointsAndDouble_ShouldOutputWinResult()
        {
            StandardBoard board = new StandardBoard();
            IBoardRegion d20 = board.Regions.Single(x => x.Code == "d20");
            DoubleWinDart dart = new DoubleWinDart(40, d20);
            Assert.AreEqual(DartResult.Win, dart.Result);
        }

        [Test]
        public void DoubleWinDart_OverPoints_ShouldOutputBustResult()
        {
            StandardBoard board = new StandardBoard();
            IBoardRegion s19 = board.Regions.Single(x => x.Code == "s19");
            DoubleWinDart dart = new DoubleWinDart(20, s19);
            Assert.AreEqual(DartResult.Bust, dart.Result);
        }

        [Test]
        public void DoubleWinDart_UnderPoints_ShouldOutputScoreResult()
        {
            StandardBoard board = new StandardBoard();
            IBoardRegion s20 = board.Regions.Single(x => x.Code == "s20");
            DoubleWinDart dart = new DoubleWinDart(22, s20);
            Assert.AreEqual(DartResult.Score, dart.Result);
        }
    }
}
