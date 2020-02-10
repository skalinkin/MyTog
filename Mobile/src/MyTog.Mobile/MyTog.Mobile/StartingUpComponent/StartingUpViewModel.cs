using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Kalinkin.MyTog.Mobile.Annotations;
using Kalinkin.MyTog.Mobile.Domain;
using TinyMessenger;
using Xamarin.Forms;

namespace Kalinkin.MyTog.Mobile.StartingUpComponent
{
    public class StartingUpViewModel : INotifyPropertyChanged
    {
        private readonly ITinyMessengerHub _hub;
        private string _message;

        public StartingUpViewModel(ITinyMessengerHub hub)
        {
            Login = new Command(OnLogin);
            _hub = hub;
        }

        private void OnLogin()
        {
            _hub.Publish(new StartAuthenticationCommand());
        }

        public string Message
        {
            get => _message;
            set
            {
                if (value == _message)
                {
                    return;
                }

                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand Login { get; set; }
    }
}