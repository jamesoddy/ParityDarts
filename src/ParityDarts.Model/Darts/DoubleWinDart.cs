using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ParityDarts.Contracts;
using ParityDarts.Model;
using System.ComponentModel.Composition;

namespace ParityDarts.Model
{
    [Export(typeof(IDart))]
    public class DoubleWinDart : IDart
    {
        int _pointsRemaining;
        IBoardRegion _region;
        IPlayer _player;

        public DoubleWinDart(int pointsRemaining, IBoardRegion region, IPlayer player)
        {
            _pointsRemaining = pointsRemaining;
            _region = region;
            _player = player;
        }

        public int Points
        {
            get
            {
                if (this.Result == DartResult.Bust)
                {
                    return 0;
                }
                else
                {
                    return this.Region.Value;
                }
            }
        }

        public int PointsRemaining
        {
            get { return _pointsRemaining; }
        }

        public IPlayer Player
        {
            get { return _player; }
        }

        public DartResult Result
        {
            get
            {
                if (this.Region.RegionType == BoardRegionType.Double && this.Region.Value == this.PointsRemaining)
                {
                    return DartResult.Win;
                }
                else if (this.Region.Value >= this.PointsRemaining - 1)
                {
                    return DartResult.Bust;
                }
                else
                {
                    return DartResult.Score;
                }
            }
        }

        public IBoardRegion Region
        {
            get { return _region; }
        }

    }
}
