using MyTog.Mobile;
using Xamarin.Forms;

namespace Kalinkin.MyTog.Mobile
{
    public class TinyIoCBootstrapper
    {
        public void Initialize()
        {
            TinyIoC.TinyIoCContainer.Current.Register<Application, App>();
        }
        public Application GetApplication()
        {
            return TinyIoC.TinyIoCContainer.Current.Resolve<Application>();
        }
    }
}