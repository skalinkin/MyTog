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
        private AggregateCatalog _aggregateCatalog = new AggregateCatalog();
        private IContainer _container;
        private CompositionContainer _mefContainer;
        [ImportMany] public List<IModule> Modules { get; set; }

        public void Initialize()
        {
            var assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            _aggregateCatalog.Catalogs.Add(new AggregateCatalog(assemblyCatalog));
            _mefContainer = new CompositionContainer(_aggregateCatalog);
        }

        public void AddAssembly(Assembly assembly)
        {
            var assemblyCatalog = new AssemblyCatalog(assembly);
            _aggregateCatalog.Catalogs.Add(assemblyCatalog);
        }

        public void MakeContainer()
        {
            _mefContainer.ComposeParts(this);
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