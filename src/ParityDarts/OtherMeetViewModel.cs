using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ParityDarts.Model;
using ParityDarts.Contracts;
using Cinch;
using System.ComponentModel.Composition;
using MEFedMVVM.ViewModelLocator;

namespace ParityDarts
{
    [Export(typeof(IMeetViewModel))]
    [ExportViewModel("OtherMeetViewModel")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class OtherMeetViewModel : EditableValidatingViewModelBase, IMeetViewModel
    {
        private IMessageBoxService messageBoxService;
        private IViewAwareStatus viewAwareStatus;
        
        private IMeet meet;

        [ImportingConstructor]
        public OtherMeetViewModel(IMessageBoxService messageBoxService, IViewAwareStatus viewAwareStatus)
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
                meet = new OtherMeet();
            }
            else
            {
                meet = view.ContextualData;
            }
        }

        public IMeet Meet
        {
            get
            {
                return meet;
            }
        }
    }
}
