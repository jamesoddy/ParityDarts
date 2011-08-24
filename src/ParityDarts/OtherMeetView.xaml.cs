using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ParityDarts.Contracts;

namespace ParityDarts
{

    public partial class OtherMeetView : UserControl, IViewContext<IMeet>
    {
        private IMeet contextualData;

        public OtherMeetView()
        {
            InitializeComponent();
        }

        public IMeet ContextualData
        {
            get
            {
                return contextualData;
            }
            set
            {
                contextualData = value;
            }
        }
    }
}
