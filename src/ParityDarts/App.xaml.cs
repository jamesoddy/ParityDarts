using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace ParityDarts
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ParityDartsBootstrapper bootstrapper = new ParityDartsBootstrapper();
            bootstrapper.Run();
            this.ShutdownMode = ShutdownMode.OnMainWindowClose;
        }
    }
}
