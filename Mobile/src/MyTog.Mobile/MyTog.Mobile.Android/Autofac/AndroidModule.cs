using System.ComponentModel.Composition;
using Autofac;
using Autofac.Core;

namespace MyTog.Mobile.Droid.Autofac
{
    [Export(typeof(IModule))]
    internal class AndroidModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
        }
    }
}