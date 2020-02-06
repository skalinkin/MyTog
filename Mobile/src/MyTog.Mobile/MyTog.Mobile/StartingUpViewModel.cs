using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using Kalinkin.MyTog.Mobile.Annotations;
using TinyMessenger;

namespace Kalinkin.MyTog.Mobile
{
    public class StartingUpViewModel : INotifyPropertyChanged
    {
        private readonly ITinyMessengerHub _messenger;
        private string _message;
        public event PropertyChangedEventHandler PropertyChanged;

        public StartingUpViewModel(ITinyMessengerHub messenger)
        {
            _messenger = messenger;
        }
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Start()
        {
            Message = "Initializing...";
            ThreadPool.QueueUserWorkItem(o => FakeLoading());
        }

        private void FakeLoading()
        {
            Thread.Sleep(1000);
            Message = "Loading...";
            Thread.Sleep(1000);
            Message = "Authenticating...";
            Thread.Sleep(2000);
            Message = "Completed";
            _messenger.Publish(new StartUpCompleted());
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
    }
}