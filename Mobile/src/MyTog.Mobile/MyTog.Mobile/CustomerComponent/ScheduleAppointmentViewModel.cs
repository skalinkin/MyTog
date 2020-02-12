using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Kalinkin.MyTog.Mobile.Annotations;
using Kalinkin.MyTog.Mobile.Domain;
using TinyMessenger;

namespace Kalinkin.MyTog.Mobile.CustomerComponent
{
    internal class ScheduleAppointmentViewModel : INotifyPropertyChanged
    {
        private readonly ITinyMessengerHub _messenger;
        private IMenuItem _selectedItem;

        public ScheduleAppointmentViewModel(IEnumerable<ICustomerMenuItem> menuItems, ITinyMessengerHub messenger)
        {
            _messenger = messenger;
            MenuItems = new ObservableCollection<ICustomerMenuItem>(menuItems);
        }

        public ObservableCollection<ICustomerMenuItem> MenuItems { get; set; }

        public IMenuItem SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (value == _selectedItem)
                {
                    return;
                }

                _selectedItem = value;

                OnPropertyChanged(nameof(SelectedItem));
                _messenger.Publish(new NavigateToCommand {Sender = this, Target = _selectedItem});
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}