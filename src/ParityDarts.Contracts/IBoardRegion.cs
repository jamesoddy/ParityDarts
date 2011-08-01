using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParityDarts.Contracts
{
    public interface IBoardRegion
    {
        BoardRegionType RegionType { get; set; }
        int Number { get; set; }
        int Value { get; set;  }
        string Code { get; set; }
    }
}
