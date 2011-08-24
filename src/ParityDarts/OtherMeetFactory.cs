using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using ParityDarts.Contracts;
using ParityDarts.Model;
using System.Windows.Controls;

namespace ParityDarts
{
    [Export(typeof(IMeetViewFactory))]
    public class OtherMeetFactory : IMeetViewFactory
    {
        public object CreateView()
        {
            return new OtherMeetView();
        }
    }
}
