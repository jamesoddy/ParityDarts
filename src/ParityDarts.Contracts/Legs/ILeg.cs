using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParityDarts.Contracts
{
    public interface ILeg
    {
        ICollection<IThrow> Throws { get; }
        LegResult Result { get; }
        IPlayer Player { get; }
    }
}
