using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TinyMessenger;

namespace Kalinkin.MyTog.Mobile.Main
{
    public class MainPageMasterViewModel : INotifyPropertyChanged
    {
        private readonly ITinyMessengerHub _messenger;
        private IMenuItem _selectedItem;

        public MainPageMasterViewModel(IEnumerable<IMenuItem> menuItems, ITinyMessengerHub messenger)
        {
            _messenger = messenger;
            MenuItems = new ObservableCollection<IMenuItem>(menuItems);
        }

        public ObservableCollection<IMenuItem> MenuItems { get; set; }

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
                _messenger.Publish(new NavigateTo {Sender = this, Target = _selectedItem});
            }
        }

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}