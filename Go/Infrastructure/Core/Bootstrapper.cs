using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Prism.Modularity;

using Microsoft.Practices.Unity;
using System.ComponentModel.Composition.Hosting;

using Go.Views;
using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Prism.MefExtensions;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.Events;

namespace Go.Infrastructure.Core
{
    class Bootstrapper : UnityBootstrapper
    {
        #region Fields

        private IRegionManager regionManager;

        private IServiceLocator serviceLocator;

        #endregion

        protected override DependencyObject CreateShell()
        {
            this.regionManager = Container.Resolve<IRegionManager>();
            this.serviceLocator = Container.Resolve<IServiceLocator>();
            
            // works somehow
            //Shell shell = Container.Resolve<Shell>();
            //return shell;

            MainWindow mainWindow = Container.Resolve<MainWindow>();

            return mainWindow;
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected virtual void ConfigureContainer()
        {
    
            RegisterTypeIfMissing(typeof(IServiceLocator), typeof(UnityServiceLocatorAdapter), true);
    RegisterTypeIfMissing(typeof(IModuleInitializer), typeof(ModuleInitializer), true);
    RegisterTypeIfMissing(typeof(IModuleManager), typeof(ModuleManager), true);
    RegisterTypeIfMissing(typeof(RegionAdapterMappings), typeof(RegionAdapterMappings), true);
    RegisterTypeIfMissing(typeof(IRegionManager), typeof(RegionManager), true);
    RegisterTypeIfMissing(typeof(IEventAggregator), typeof(EventAggregator), true);
    RegisterTypeIfMissing(typeof(IRegionViewRegistry), typeof(RegionViewRegistry), true);
    RegisterTypeIfMissing(typeof(IRegionBehaviorFactory), typeof(RegionBehaviorFactory), true);

    this.RegisterBootstrapperProvidedTypes();
}



        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            RegionAdapterMappings regionAdapterMappings = Container.TryResolve<RegionAdapterMappings>();

            if (regionAdapterMappings != null)
            {
                regionAdapterMappings.RegisterMapping(typeof(Window), new RegionAdapter(this.serviceLocator));
            }

            return base.ConfigureRegionAdapterMappings();
        }

        //protected virtual void ConfigureContainer()
        //{
        //    this.RegisterBootstrapperProvidedTypes();
        //}

        protected virtual void RegisterBootstrapperProvidedTypes()
        {
            //this.Container.ComposeExportedValue<ILoggerFacade>(this.Logger);
            //this.Container.ComposeExportedValue<IModuleCatalog>(this.ModuleCatalog);
            //this.Container.ComposeExportedValue<IServiceLocator>(new MefServiceLocatorAdapter(this.Container));
            //this.Container.ComposeExportedValue<AggregateCatalog>(this.AggregateCatalog);
        }

        //protected override IModuleCatalog CreateModuleCatalog()
        //{
        //    return new DirectoryModuleCatalog() { ModulePath = @"Modules" };
        //}
    }
}
