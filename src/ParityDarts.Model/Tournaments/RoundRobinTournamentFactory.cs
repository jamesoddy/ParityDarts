using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ParityDarts.Contracts;
using System.ComponentModel.Composition;

namespace ParityDarts.Model
{
    [Export(typeof(ITournamentFactory))]
    public class RoundRobinTournamentFactory : ITournamentFactory
    {
        public ITournament CreateTournament(IMeet meet)
        {
            ITournament tournament= new RoundRobinTournament(meet);
            return tournament;
        }
    }
}
