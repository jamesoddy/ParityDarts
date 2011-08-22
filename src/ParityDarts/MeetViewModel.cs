using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using MEFedMVVM.ViewModelLocator;

namespace ParityDarts
{
    [ExportViewModel("MeetViewModel")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class MeetViewModel : Cinch.ViewModelBase
    {
    }
}
