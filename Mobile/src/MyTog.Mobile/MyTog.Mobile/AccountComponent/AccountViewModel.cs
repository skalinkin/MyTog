using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Kalinkin.MyTog.Mobile.Annotations;
using Kalinkin.MyTog.Mobile.Domain;
using TinyMessenger;
using Xamarin.Forms;

namespace Kalinkin.MyTog.Mobile.AccountComponent
{
    public class AccountViewModel:INotifyPropertyChanged
    {
        private readonly ITinyMessengerHub _hub;

        public AccountViewModel(ITinyMessengerHub hub)
        {
            _hub = hub;
            Logout = new Command(()=> _hub.Publish(new LogoutCommand()));
        }
        public ICommand Logout { private set; get; }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}