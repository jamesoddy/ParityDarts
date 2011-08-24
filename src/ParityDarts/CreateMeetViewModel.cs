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
using Microsoft.Practices.Prism.Regions;
using System.Windows;
using ParityDarts.Regions;
using System.Windows.Controls;
using ParityDarts.Model;

namespace ParityDarts
{
    [ExportViewModel("CreateMeetViewModel")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CreateMeetViewModel : Cinch.ViewModelBase
    {
        [ImportMany(typeof(IMeetViewFactory))]
        IEnumerable<IMeetViewFactory> meetFactories;

        private IMeetViewFactory selectedMeetFactory;

        private IViewAwareStatus viewAwareStatus;
        private IMessageBoxService messageBoxService;

        [ImportingConstructor]
        public CreateMeetViewModel(IViewAwareStatus viewAwareStatus, IMessageBoxService messageBoxService)
        {
            this.viewAwareStatus = viewAwareStatus;
            this.messageBoxService = messageBoxService;

            //Commands
            CreateMeetCommand = new SimpleCommand<Object, Object>(CanExecuteCreateMeetCommand, ExecuteCreateMeetCommand);

            Mediator.Instance.Register(this);
        }

        public IEnumerable<IMeetViewFactory> MeetFactories
        {
            get
            {
                return meetFactories;
            }
        }

        public SimpleCommand<object, object> CreateMeetCommand { get; private set; }

        private bool CanExecuteCreateMeetCommand(Object args)
        {
            return (SelectedMeetFactory != null);
        }

        private void ExecuteCreateMeetCommand(Object args)
        {

            IRegionManager regionManager = RegionManager.GetRegionManager(
                (DependencyObject)viewAwareStatus.View);
            IRegion region = regionManager.Regions[RegionNames.MainRegion];

            IViewContext<IMeet> meetView = (IViewContext<IMeet>)SelectedMeetFactory.CreateView();
            meetView.ContextualData = new StandardMeet() { Name = "TestName" };
            region.Add(meetView);
            region.Activate(meetView);
        }

        static PropertyChangedEventArgs selectedMeetFactoryArgs =
            ObservableHelper.CreateArgs<CreateMeetViewModel>(x => x.SelectedMeetFactory);

        public IMeetViewFactory SelectedMeetFactory
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
