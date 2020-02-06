using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kalinkin.MyTog.Mobile.DefaultModeComponent
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DefaultModeMainPageMaster : ContentPage
    {
        public ListView ListView;

        public DefaultModeMainPageMaster()
        {
            InitializeComponent();

            BindingContext = new DefaultModeMainPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class DefaultModeMainPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<DefaultModeMainPageMasterMenuItem> MenuItems { get; set; }

            public DefaultModeMainPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<DefaultModeMainPageMasterMenuItem>(new[]
                {
                    new DefaultModeMainPageMasterMenuItem { Id = 0, Title = "Page 1" },
                    new DefaultModeMainPageMasterMenuItem { Id = 1, Title = "Page 2" },
                    new DefaultModeMainPageMasterMenuItem { Id = 2, Title = "Page 3" },
                    new DefaultModeMainPageMasterMenuItem { Id = 3, Title = "Page 4" },
                    new DefaultModeMainPageMasterMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}