using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParityDarts.Contracts
{
    public interface ITournamentFactory
    {
        ITournament CreateTournament(IMeet meet);
    }
}
