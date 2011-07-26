using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParityDarts.Model
{
    public interface IDart
    { 
        int Points { get; set; }
        int PointsRemaining { get; set; }
        DartResult Result { get; set; }
    }
}
