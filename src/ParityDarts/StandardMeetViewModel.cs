using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ParityDarts.Model;
using ParityDarts.Contracts;
using Cinch;
using System.ComponentModel.Composition;
using MEFedMVVM.ViewModelLocator;
using MEFedMVVM.Common;
using System.ComponentModel;

namespace ParityDarts
{
    [Export(typeof(IMeetViewModel))]
    [ExportViewModel("StandardMeetViewModel")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class StandardMeetViewModel : EditableValidatingViewModelBase, IMeetViewModel
    {
        private IMessageBoxService messageBoxService;
        private IViewAwareStatus viewAwareStatus;
        
        private IMeet meet;

        [ImportingConstructor]
        public StandardMeetViewModel(IMessageBoxService messageBoxService, IViewAwareStatus viewAwareStatus)
        {
            this.messageBoxService = messageBoxService;
            this.viewAwareStatus = viewAwareStatus;
            this.viewAwareStatus.ViewLoaded += ViewAwareStatus_ViewLoaded;
        }

        private void ViewAwareStatus_ViewLoaded()
        {
            IViewContext<IMeet> view = (IViewContext<IMeet>)viewAwareStatus.View;
            if (view.ContextualData == null)
            {
                this.Meet = new StandardMeet();
            }
            else
            {
                this.Meet = view.ContextualData;
            }
        }

        static PropertyChangedEventArgs meetArgs =
            ObservableHelper.CreateArgs<StandardMeetViewModel>(x => x.Meet);

        public IMeet Meet
        {
            get
            {
                return meet;
            }
            private set
            {
                meet = value;
                NotifyPropertyChanged(meetArgs);
            }
        }
    }
}
