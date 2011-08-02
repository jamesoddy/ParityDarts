using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ParityDarts.Contracts;
using System.ComponentModel.Composition;

namespace ParityDarts.Model
{
    [Export(typeof(IBoard))]
    public class StandardBoard : IBoard
    {

        private HashSet<IBoardRegion> _regions;

        public IEnumerable<IBoardRegion> Regions
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

        public void BuildRegions()
        {
            _regions = new HashSet<IBoardRegion>();

            // Regions 1 to 20
            for (int i = 1; i <= 20; i++)
            {
                StandardBoardRegion newTrebleRegion = new StandardBoardRegion();
                newTrebleRegion.Number = i;
                newTrebleRegion.RegionType = BoardRegionType.Treble;
                newTrebleRegion.Value = i * 3;
                newTrebleRegion.Code = string.Format("t{0:0}", i);
                _regions.Add(newTrebleRegion);
                StandardBoardRegion newDoubleRegion = new StandardBoardRegion();
                newDoubleRegion.Number = i;
                newDoubleRegion.RegionType = BoardRegionType.Double;
                newDoubleRegion.Value = i * 2;
                newDoubleRegion.Code = string.Format("d{0:0}", i);
                _regions.Add(newDoubleRegion);
                StandardBoardRegion newSingleRegion = new StandardBoardRegion();
                newSingleRegion.Number = i;
                newSingleRegion.RegionType = BoardRegionType.Single;
                newSingleRegion.Value = i;
                newSingleRegion.Code = string.Format("s{0:0}", i);
                _regions.Add(newSingleRegion);
            }

            // Outer region
            StandardBoardRegion outerRegion = new StandardBoardRegion();
            outerRegion.Number = 25;
            outerRegion.RegionType = BoardRegionType.Single;
            outerRegion.Value = 25;
            outerRegion.Code = "O";
            _regions.Add(outerRegion);
            
            // Bull region
            StandardBoardRegion bullRegion = new StandardBoardRegion();
            bullRegion.Number = 25;
            bullRegion.RegionType = BoardRegionType.Double;
            bullRegion.Value = 50;
            bullRegion.Code = "B";
            _regions.Add(bullRegion);
            
            // Miss region
            StandardBoardRegion missRegion = new StandardBoardRegion();
            missRegion.Number = 0;
            missRegion.RegionType = BoardRegionType.Miss;
            missRegion.Value = 0;
            missRegion.Code = "M";
            _regions.Add(missRegion);
            
            // Bounce out region
            StandardBoardRegion bounceOutRegion = new StandardBoardRegion();
            bounceOutRegion.Number = 0;
            bounceOutRegion.RegionType = BoardRegionType.Miss;
            bounceOutRegion.Value = 0;
            bounceOutRegion.Code = "BO";
            _regions.Add(bounceOutRegion);

        }

    }

}
