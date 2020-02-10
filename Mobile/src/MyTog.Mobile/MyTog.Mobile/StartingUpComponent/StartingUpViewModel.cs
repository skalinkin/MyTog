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
        private readonly CurrentUserService _currentUser;
        private string _message;
        private bool _isBusy;
        private bool _canLogin = true;

        public StartingUpViewModel(ITinyMessengerHub hub, CurrentUserService currentUser)
        {
            Login = new Command(OnLogin);
            _hub = hub;
            _currentUser = currentUser;

            _hub.Subscribe<ApplicationResumedEvent>(ResetView);
        }

        private async void ResetView(ApplicationResumedEvent obj)
        {
            IsBusy = false;

            CanLogin = await _currentUser.IsUserNeedAuthentication();
        }

        private void OnLogin()
        {
            IsBusy = true;
            CanLogin = false;
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

        public bool CanLogin
        {
            get => _canLogin;
            set
            {
                if (value == _canLogin) return;
                _canLogin = value;
                OnPropertyChanged();
            }
        } 

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (value == _isBusy) return;
                _isBusy = value;
                OnPropertyChanged();
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