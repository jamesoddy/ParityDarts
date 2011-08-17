using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ParityDarts.Contracts;
using System.ComponentModel.Composition;

namespace ParityDarts.Model
{
    [Export(typeof(IThrow))]
    public class StandardThrow : IThrow
    {
        int _startingPointsRemaining;
        HashSet<IDart> _darts = new HashSet<IDart>();

        public StandardThrow(int startingPointsRemaining)
        {
            _startingPointsRemaining = startingPointsRemaining;
        }

        public ICollection<IDart> Darts
        {
            get { return _darts; }
        }

        public int Points
        {
            get
            {
                if (this.Result == ThrowResult.Bust)
                {
                    return 0;
                }
                else
                {
                    return Darts.Sum(x => x.Points);
                }
            }
        }

        public int PointsRemaining
        {
            get 
            {
                return _startingPointsRemaining - Points; 
            }
        }

        public ThrowResult Result
        {
            get
            {
                foreach (IDart dart in this.Darts)
                {
                    if (dart.Result == DartResult.Win)
                    {
                        return ThrowResult.Win;
                    }
                    else if (dart.Result == DartResult.Bust)
                    {
                        return ThrowResult.Bust;
                    }
                }
                return ThrowResult.Score;
            }
        }
    }
}
