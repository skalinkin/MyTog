using System.ComponentModel;
using System.Runtime.CompilerServices;
using Kalinkin.MyTog.Mobile.Annotations;
using Kalinkin.MyTog.Mobile.Domain;
using TinyMessenger;

namespace Kalinkin.MyTog.Mobile.StartingUpComponent
{
    public class StartingUpViewModel : INotifyPropertyChanged
    {
        private readonly ITinyMessengerHub _messenger;
        private string _message;

        public StartingUpViewModel(ITinyMessengerHub messenger)
        {
            _messenger = messenger;
            _messenger.Subscribe<StartUpStatus>(OnStartUpStatus);
        }

        private void OnStartUpStatus(StartUpStatus obj)
        {
            Message = obj.StatusText;
        }

        public string Message
        {
            get => _message;
            set
            {
                if (value == _message) return;
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

        public void Start()
        {
            Message = "Initializing...";
        }
    }
}