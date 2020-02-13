using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Kalinkin.MyTog.Mobile.Annotations;
using TinyMessenger;
using Xamarin.Forms;

namespace Kalinkin.MyTog.Mobile.CustomerComponent
{
    public class ScheduleAppointmentViewModel : INotifyPropertyChanged
    {
        private readonly ITinyMessengerHub _hub;
        private DateTime _selectedDate;

        public ScheduleAppointmentViewModel(IEnumerable<ICustomerMenuItem> menuItems, ITinyMessengerHub hub)
        {
            _hub = hub;
            MenuItems = new ObservableCollection<ICustomerMenuItem>(menuItems);
            Submit = new Command(OnSubmit);
        }

        public ObservableCollection<ICustomerMenuItem> MenuItems { get; set; }

        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                if (value == _selectedDate)
                {
                    return;
                }

                _selectedDate = value;

                OnPropertyChanged(nameof(SelectedDate));
            }
        }

        public string Message { get; set; }

        public ICommand Submit { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnSubmit()
        {
            _hub.Publish(new ScheduleAppointmentCommand {Message = Message});
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}