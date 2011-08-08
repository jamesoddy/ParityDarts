using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParityDarts.Contracts
{
    public interface IThrow
    {
        ICollection<IDart> Darts { get; }
        int Points { get; }
        int PointsRemaining { get; }
        ThrowResult Result { get; }
        IPlayer Player { get; }
    }
}
