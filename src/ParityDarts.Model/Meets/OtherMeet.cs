using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using ParityDarts.Contracts;

namespace ParityDarts.Model
{
    [Export(typeof(IMeet))]
    public class OtherMeet : IMeet
    {
        private IList<ITournament> _tournaments = new List<ITournament>();

        public IList<ITournament> Tournaments
        {
            get { return _tournaments; }
        }

        public string Name
        {
            get;
            set;
        }
    }
}
