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

namespace ParityDarts
{
    [ExportViewModel("ShellViewModel")]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ShellViewModel : Cinch.ViewModelBase
    {
        #region Data
        
        private IViewAwareStatus viewAwareStatus;
        private IMessageBoxService messageBoxService;

        #endregion

        [ImportingConstructor]
        public ShellViewModel(IViewAwareStatus viewAwareStatus,
            IMessageBoxService messageBoxService)
        {
            this.viewAwareStatus = viewAwareStatus;
            this.messageBoxService = messageBoxService;
            this.viewAwareStatus.ViewLoaded += ViewAwareStatus_ViewLoaded;

            //Commands
            AddNewMeetCommand = new SimpleCommand<Object, Object>(ExecuteAddNewMeetCommand);


            Mediator.Instance.Register(this);
        }




        public SimpleCommand<Object, Object> AddNewMeetCommand { get; private set; }




        #region Private Methods

        private void ViewAwareStatus_ViewLoaded()
        {
            IRegionManager regionManager =
                RegionManager.GetRegionManager((DependencyObject)viewAwareStatus.View);
            //IRegion region = regionManager.Regions[RegionNames.MainRegion];            
        }

        private void ExecuteAddNewMeetCommand(Object args)
        {
            messageBoxService.ShowInformation("Add new meet.");
            //IRegionManager regionManager = RegionManager.GetRegionManager(
            //    (DependencyObject)viewAwareStatus.View);
            //IRegion region = regionManager.Regions[RegionNames.MainRegion];

            //GoogleImageSearchView googleImageSearchView =
            //    ViewModelRepository.Instance.Resolver.Container.GetExport<GoogleImageSearchView>().Value;
            //googleImageSearchView.ContextualData =
            //    new Model.GoogleImageSearchInfo(
            //        randomSearchTerms[rand.Next(randomSearchTerms.Length)],
            //        string.Format("Imageregion_{0}", searchViewsCounter++));
            //region.Add(googleImageSearchView);
            //region.Activate(googleImageSearchView);
            //searchViewsInstanceCounter++;
        }

        #endregion






    }
}
