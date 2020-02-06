using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Kalinkin.MyTog.Mobile.Main
{
    public class MainPageMasterViewModel : INotifyPropertyChanged
    {
        public MainPageMasterViewModel(IEnumerable<IMenuItem> menuItems)
        {
            MenuItems = new ObservableCollection<IMenuItem>(menuItems);
        }

        public ObservableCollection<IMenuItem> MenuItems { get; set; }

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}