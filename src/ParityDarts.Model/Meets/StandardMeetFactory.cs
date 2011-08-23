using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using ParityDarts.Contracts;

namespace ParityDarts.Model
{
    [Export(typeof(IMeetFactory))]
    public class StandardMeetFactory : IMeetFactory
    {
        public IMeet CreateMeet()
        {
            return new StandardMeet();
        }
    }
}
