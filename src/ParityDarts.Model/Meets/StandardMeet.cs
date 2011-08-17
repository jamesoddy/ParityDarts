using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using ParityDarts.Contracts;

namespace ParityDarts.Model
{
    [Export(typeof(IMeet))]
    public class StandardMeet : IMeet
    {
        private ISet<ITournament> _tournaments = new HashSet<ITournament>();

        public ISet<ITournament> Tournaments
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
