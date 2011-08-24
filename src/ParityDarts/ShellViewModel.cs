using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MEFedMVVM.ViewModelLocator;
using System.ComponentModel.Composition;
using Cinch;
using Microsoft.Practices.Prism.Regions;
using System.Windows;
using ParityDarts.Regions;
using System.Collections.ObjectModel;

namespace ParityDarts
{
    [ExportViewModel("ShellViewModel")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ShellViewModel : Cinch.ViewModelBase
    {
        
        private IViewAwareStatus viewAwareStatus;
        private IMessageBoxService messageBoxService;

        private ObservableCollection<ViewModelBase> workspaces;


        [ImportingConstructor]
        public ShellViewModel(IViewAwareStatus viewAwareStatus,
            IMessageBoxService messageBoxService)
        {
            this.viewAwareStatus = viewAwareStatus;
            this.messageBoxService = messageBoxService;

            //Commands
            AddNewMeetCommand = new SimpleCommand<Object, Object>(ExecuteAddNewMeetCommand);
            
            Mediator.Instance.Register(this);
        }
        
        public SimpleCommand<Object, Object> AddNewMeetCommand { get; private set; }
        
        private void ExecuteAddNewMeetCommand(Object args)
        {
            messageBoxService.ShowInformation("Add new meet.");

            IRegionManager regionManager = RegionManager.GetRegionManager(
                (DependencyObject)viewAwareStatus.View);
            IRegion region = regionManager.Regions[RegionNames.MainRegion];

            CreateMeetView createMeetView = new CreateMeetView();
            region.Add(createMeetView);
            region.Activate(createMeetView);
        }

    }
}
