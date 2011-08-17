using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using ParityDarts.Contracts;

namespace ParityDarts.Model
{
    [Export(typeof(ITournament))]
    public class RoundRobinTournament : ITournament
    {
        public RoundRobinTournament(IMeet meet)
        {
            this.Meet = meet;
        }

        public IMeet Meet
        {
            get;
            private set;
        }
    }
}
