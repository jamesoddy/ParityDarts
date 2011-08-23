using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Microsoft.Practices.Prism.MefExtensions;
using Microsoft.Practices.Prism.Regions;
using Cinch;
using System.Reflection;
using MEFedMVVM.ViewModelLocator;
using System.Windows.Controls;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;

namespace ParityDarts
{
    public class ParityDartsBootstrapper : MefBootstrapper, IComposer, IContainerProvider
    {

        private CompositionContainer _compositionContainer;

        public override void Run(bool runWithDefaultConfiguration)
        {
            base.Run(runWithDefaultConfiguration);
        }

        #region Overrides of Bootstrapper
        protected override void ConfigureAggregateCatalog()
        {
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(App).Assembly));
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(Cinch.WPFMessageBoxService).Assembly));
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog("ParityDarts.Model.dll"));
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            MEFedMVVM.ViewModelLocator.LocatorBootstrapper.ApplyComposer(this);

            CinchBootStrapper.Initialise(new List<Assembly> { typeof(App).Assembly });

            Application.Current.MainWindow = (Shell)this.Shell;
            Application.Current.MainWindow.Show();
        }


        protected override DependencyObject CreateShell()
        {
            return this.Container.GetExportedValue<Shell>();
        }
        #endregion

        #region Implementation of IComposer (For MEFedMVVM)

        public ComposablePartCatalog InitializeContainer()
        {
            //return the same catalog as the PRISM one
            return this.AggregateCatalog;
        }

        public IEnumerable<ExportProvider> GetCustomExportProviders()
        {
            //In case you want some custom export providers
            return null;
        }

        #endregion


        protected override CompositionContainer CreateContainer()
        {
            // The Prism call to create a container
            var exportProvider = new MEFedMVVMExportProvider(MEFedMVVMCatalog.CreateCatalog(AggregateCatalog));
            _compositionContainer = new CompositionContainer(exportProvider);
            exportProvider.SourceProvider = _compositionContainer;

            return _compositionContainer;
        }


        CompositionContainer IContainerProvider.CreateContainer()
        {
            // The MEFedMVVM call to create a container
            return _compositionContainer;
        }
    }
}
