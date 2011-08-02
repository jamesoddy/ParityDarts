using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParityDarts.Contracts
{
    public interface IBoard
    {
        IEnumerable<IBoardRegion> Regions { get; }
    }
}
