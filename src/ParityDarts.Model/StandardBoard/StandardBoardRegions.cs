using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ParityDarts.Contracts;

namespace ParityDarts.Model
{
    public class StandardBoard
    {
        private static ICollection<BoardRegion> _regions;

        public static ICollection<BoardRegion> Regions
        {
            get
            {
                if (_regions == null)
                {
                    BuildRegions();
                }
                return _regions;
            }
        }
        public static void BuildRegions()
        {
            _regions = new HashSet<BoardRegion>();

            // Regions 1 to 20
            for (int i = 1; i <= 20; i++)
            {
                BoardRegion newTrebleRegion = new BoardRegion();
                newTrebleRegion.Number = i;
                newTrebleRegion.RegionType = BoardRegionType.Treble;
                newTrebleRegion.Value = i * 3;
                newTrebleRegion.Code = string.Format("t{0:0}", i);
                _regions.Add(newTrebleRegion);
                BoardRegion newDoubleRegion = new BoardRegion();
                newDoubleRegion.Number = i;
                newDoubleRegion.RegionType = BoardRegionType.Double;
                newDoubleRegion.Value = i * 2;
                newTrebleRegion.Code = string.Format("d{0:0}", i);
                _regions.Add(newDoubleRegion);
                BoardRegion newSingleRegion = new BoardRegion();
                newSingleRegion.Number = i;
                newSingleRegion.RegionType = BoardRegionType.Single;
                newSingleRegion.Value = i;
                newTrebleRegion.Code = string.Format("s{0:0}", i);
                _regions.Add(newSingleRegion);
            }

            // Outer region
            BoardRegion outerRegion = new BoardRegion();
            outerRegion.Number = 25;
            outerRegion.RegionType = BoardRegionType.Single;
            outerRegion.Value = 25;
            outerRegion.Code = "O";
            _regions.Add(outerRegion);
            
            // Bull region
            BoardRegion bullRegion = new BoardRegion();
            bullRegion.Number = 25;
            bullRegion.RegionType = BoardRegionType.Double;
            bullRegion.Value = 50;
            bullRegion.Code = "B";
            _regions.Add(bullRegion);
            
            // Miss region
            BoardRegion missRegion = new BoardRegion();
            missRegion.Number = 0;
            missRegion.RegionType = BoardRegionType.Miss;
            missRegion.Value = 0;
            missRegion.Code = "M";
            _regions.Add(missRegion);
            
            // Bounce out region
            BoardRegion bounceOutRegion = new BoardRegion();
            bounceOutRegion.Number = 0;
            bounceOutRegion.RegionType = BoardRegionType.Miss;
            bounceOutRegion.Value = 0;
            bounceOutRegion.Code = "BO";
            _regions.Add(bounceOutRegion);

        }

    }

}
