using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ParityDarts.Contracts;

namespace ParityDarts.Model
{
    public class StandardBoardRegion : IBoardRegion
    {
        public BoardRegionType RegionType
        {
            get;
            set;
        }

        public int Number
        {
            get;
            set;
        }

        public int Value
        {
            get;
            set;
        }

        public string Code
        {
            get;
            set;
        }
    }
}
