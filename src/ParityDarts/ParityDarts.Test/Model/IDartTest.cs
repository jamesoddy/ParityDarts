using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ParityDarts.Model;

namespace ParityDarts.Test.Model
{
    //[TestFixture]
    public class IDartTest
    {
        //[Test]
        public void IDart_EqualPoints_ShouldOutputWinResult(IDart dart)
        {
            dart.PointsRemaining = 60;
            dart.Points = 60;
            // Should yield win result
        }
    }
}
