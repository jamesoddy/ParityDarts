using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ParityDarts.Contracts;

namespace ParityDarts.Model.Test
{
    [TestFixture]
    public class StandardThrowTest
    {
        [Test]
        public void StandardThrow_ShouldAddValueOfDartsIfNotBust()
        {
            StandardThrow standardThrow = new StandardThrow(100);
            StandardBoard board = new StandardBoard();
            IBoardRegion s20 = board.Regions.Single(x => x.Code == "s20");

            int expectedPoints = 60;

            DoubleWinDart dart1 = new DoubleWinDart(standardThrow.PointsRemaining, s20);
            standardThrow.Darts.Add(dart1);

            DoubleWinDart dart2 = new DoubleWinDart(standardThrow.PointsRemaining, s20);
            standardThrow.Darts.Add(dart2);

            DoubleWinDart dart3 = new DoubleWinDart(standardThrow.PointsRemaining, s20);
            standardThrow.Darts.Add(dart3);

            Assert.AreNotEqual(ThrowResult.Bust, standardThrow.Result);
            Assert.AreEqual(expectedPoints, standardThrow.Points);
        }

        [Test]
        public void StandardThrow_ShouldReturnBustIfADartBusts()
        {
            StandardThrow standardThrow = new StandardThrow(2);
            StandardBoard board = new StandardBoard();
            IBoardRegion d1 = board.Regions.Single(x => x.Code == "d1");
            IBoardRegion s1 = board.Regions.Single(x => x.Code == "s1");

            DoubleWinDart dart1 = new DoubleWinDart(standardThrow.PointsRemaining, s1);
            standardThrow.Darts.Add(dart1);
            Assert.AreEqual(DartResult.Bust, dart1.Result);
            Assert.AreEqual(ThrowResult.Bust, standardThrow.Result);
        }

        [Test]
        public void StandardThrow_ShouldReturnWinIfADartWins()
        {
            StandardThrow standardThrow = new StandardThrow(50);
            StandardBoard board = new StandardBoard();
            IBoardRegion bull = board.Regions.Single(x => x.Code == "B");

            DoubleWinDart dart1 = new DoubleWinDart(standardThrow.PointsRemaining, bull);
            standardThrow.Darts.Add(dart1);
            Assert.AreEqual(DartResult.Win, dart1.Result);
            Assert.AreEqual(ThrowResult.Win, standardThrow.Result);
        }

        [Test]
        public void StandardThrow_ShouldReturnZeroPointsIfBust()
        {
            StandardThrow standardThrow = new StandardThrow(40);
            StandardBoard board = new StandardBoard();
            IBoardRegion s20 = board.Regions.Single(x => x.Code == "s20");
            
            DoubleWinDart dart1 = new DoubleWinDart(standardThrow.PointsRemaining, s20);
            standardThrow.Darts.Add(dart1);

            DoubleWinDart dart2 = new DoubleWinDart(standardThrow.PointsRemaining, s20);
            standardThrow.Darts.Add(dart2);
            
            Assert.AreEqual(ThrowResult.Bust, standardThrow.Result);
            Assert.AreEqual(0, standardThrow.Points);
            Assert.AreEqual(40, standardThrow.PointsRemaining);
        }

        [Test]
        public void StandardThrow_ShouldReducePointsRemaining()
        {
            StandardThrow standardThrow = new StandardThrow(120);
            StandardBoard board = new StandardBoard();
            IBoardRegion outer = board.Regions.Single(x => x.Code == "O");
            IBoardRegion d15 = board.Regions.Single(x => x.Code == "d15");

            DoubleWinDart dart1 = new DoubleWinDart(standardThrow.PointsRemaining, outer);
            standardThrow.Darts.Add(dart1);
            Assert.AreEqual(95, standardThrow.PointsRemaining);

            DoubleWinDart dart2 = new DoubleWinDart(standardThrow.PointsRemaining, d15);
            standardThrow.Darts.Add(dart2);
            Assert.AreEqual(65, standardThrow.PointsRemaining);
        }

    }
}
