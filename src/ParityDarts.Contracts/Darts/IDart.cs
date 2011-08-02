using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParityDarts.Contracts
{
    public interface IDart
    {
        int Points { get; }
        int PointsRemaining { get; }
        DartResult Result { get; }
        IBoardRegion Region { get; }
    }
}
