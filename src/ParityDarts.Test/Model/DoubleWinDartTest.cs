using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ParityDarts.Model;
using NUnit.Framework;
using ParityDarts.Contracts;

namespace ParityDarts.Test.Model
{
    [TestFixture]
    public class DoubleWinDartTest
    {
        [Test]
        public void DoubleWinDart_EqualPointsAndDouble_ShouldOutputWinResult()
        {
            BoardRegion d20 = StandardBoard.Regions.Single(x => x.Code == "d20");
            DoubleWinDart dart = new DoubleWinDart(40, d20);
            Assert.AreEqual(DartResult.Win, dart.Result);
        }

        [Test]
        public void DoubleWinDart_OverPoints_ShouldOutputBustResult()
        {
            BoardRegion t20 = StandardBoard.Regions.Single(x => x.Code == "t20");
            DoubleWinDart dart = new DoubleWinDart(40, t20);
            Assert.AreEqual(DartResult.Bust, dart.Result);
        }

        [Test]
        public void DoubleWinDart_UnderPoints_ShouldOutputScoreResult()
        {
            BoardRegion s20 = StandardBoard.Regions.Single(x => x.Code == "s20");
            DoubleWinDart dart = new DoubleWinDart(40, s20);
            Assert.AreEqual(DartResult.Score, dart.Result);
        }
    }
}
