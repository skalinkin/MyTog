using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using Autofac;
using Autofac.Core;
using Xamarin.Forms;

namespace Kalinkin.MyTog.Mobile.Autofac
{
    public class AutofacBootstrapper
    {
        private IContainer _container;
        [ImportMany] public List<IModule> Modules { get; set; }

        public void Initialize()
        {
            var directoryCatalog = new DirectoryCatalog("*.dll");
            var assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var aggregateCatalog = new AggregateCatalog(assemblyCatalog, directoryCatalog);
            aggregateCatalog.Catalogs.Add(directoryCatalog);

            var container = new CompositionContainer(aggregateCatalog);

            container.ComposeParts(this);
            var builder = new ContainerBuilder();
            foreach (var module in Modules) builder.RegisterModule(module);
            _container = builder.Build();
        }

        public Application GetApplication()
        {
            var app = _container.Resolve<Application>();
            return app;
        }
    }
}