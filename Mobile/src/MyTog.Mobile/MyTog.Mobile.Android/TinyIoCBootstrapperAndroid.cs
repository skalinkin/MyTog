using Kalinkin.MyTog.Mobile;

namespace MyTog.Mobile.Droid
{
    internal class TinyIoCBootstrapperAndroid
    {
        public void Initialize()
        {
            TinyIoC.TinyIoCContainer.Current.Register<IAuthenticationService, Auth0AuthenticationService>();
        }
    }
}