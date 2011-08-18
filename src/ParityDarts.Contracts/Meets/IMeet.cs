using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParityDarts.Contracts
{
    public interface IMeet
    {
        IList<ITournament> Tournaments { get; }
        string Name { get; set; }
    }
}
