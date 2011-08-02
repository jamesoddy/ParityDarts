using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace ParityDarts.Model.Test
{
    [TestFixture]
    public class StandardBoardTest
    {
        [Test]
        public void StandardBoard_ShouldReturn64BoardRegions()
        {
            StandardBoard board = new StandardBoard();
            int regionCount = board.Regions.Count();
            Assert.AreEqual(64, regionCount);
        }

    }
}
