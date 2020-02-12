using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Kalinkin.MyTog.Mobile.Annotations;
using Kalinkin.MyTog.Mobile.Domain;
using TinyMessenger;
using Xamarin.Forms;

namespace Kalinkin.MyTog.Mobile.StartingUpComponent
{
    public class SelectingModeViewModel:INotifyPropertyChanged
    {
        private readonly ITinyMessengerHub _hub;

        public SelectingModeViewModel(ITinyMessengerHub hub)
        {
            _hub = hub;
            NeedTog = new Command(OnNeedTog);
            AmATog = new Command(OnAmATog);
        }

        private void OnAmATog()
        {
            _hub.Publish(new LunchPhotographerModeCommand());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand NeedTog { get; set; }

        private void OnNeedTog()
        {
            _hub.Publish(new LunchCustomerModeCommand());
        }

        public ICommand AmATog { get; set; }
        public ICommand AmAssociate { get; set; }
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}