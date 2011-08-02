using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ParityDarts.Contracts;

namespace ParityDarts.Model.Test.Boards
{
    [TestFixture]
    public class StandardBoardRegionTest
    {
        [Test]
        public void StandardBoardRegion_ShouldReturnGivenValues()
        {
            StandardBoardRegion region = new StandardBoardRegion();
            region.Code = "TestCode";
            region.Number = 20;
            region.RegionType = BoardRegionType.Single;
            region.Value = 20;
            Assert.AreEqual("TestCode", region.Code);
            Assert.AreEqual(20, region.Number);
            Assert.AreEqual(BoardRegionType.Single, region.RegionType);
            Assert.AreEqual(20, region.Value);
        }
    }
}
