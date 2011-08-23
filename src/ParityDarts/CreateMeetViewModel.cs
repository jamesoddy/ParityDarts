using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using MEFedMVVM.ViewModelLocator;
using ParityDarts.Contracts;
using Cinch;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ParityDarts
{
    [ExportViewModel("CreateMeetViewModel")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CreateMeetViewModel : Cinch.ViewModelBase
    {
        [ImportMany(typeof(IMeetFactory))]
        IEnumerable<IMeetFactory> meetFactories;

        private IMeetFactory selectedMeetFactory;

        private IViewAwareStatus viewAwareStatus;
        private IMessageBoxService messageBoxService;

        [ImportingConstructor]
        public CreateMeetViewModel(IViewAwareStatus viewAwareStatus,
            IMessageBoxService messageBoxService)
        {
            this.viewAwareStatus = viewAwareStatus;
            this.messageBoxService = messageBoxService;

            //Commands
            CreateMeetCommand = new SimpleCommand<Object, Object>(CanExecuteCreateMeetCommand, ExecuteCreateMeetCommand);
            SelectMeetFactoryCommand = new SimpleCommand<object, object>(ExecuteSelectMeetFactoryCommand);

            Mediator.Instance.Register(this);
        }

        public IEnumerable<IMeetFactory> MeetFactories
        {
            get
            {
                return meetFactories;
            }
        }

        public SimpleCommand<object, object> SelectMeetFactoryCommand { get; private set; }

        public SimpleCommand<object, object> CreateMeetCommand { get; private set; }

        private bool CanExecuteCreateMeetCommand(Object args)
        {
            return (SelectedMeetFactory != null);
        }

        private void ExecuteCreateMeetCommand(Object args)
        {
            IMeet meet = SelectedMeetFactory.CreateMeet();
            messageBoxService.ShowInformation(string.Format("Created Meet {0}", meet.GetType().Name));
        }

        private void ExecuteSelectMeetFactoryCommand(Object args)
        {

        }


        static PropertyChangedEventArgs selectedMeetFactoryArgs =
            ObservableHelper.CreateArgs<CreateMeetViewModel>(x => x.SelectedMeetFactory);

        public IMeetFactory SelectedMeetFactory
        {
            get { return selectedMeetFactory; }
            set
            {
                selectedMeetFactory = value;
                NotifyPropertyChanged(selectedMeetFactoryArgs);
            }
        }


    }
}
