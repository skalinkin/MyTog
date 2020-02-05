using Xamarin.Forms;

namespace MyTog.Mobile
{
    public partial class App : Application
    {
        public App(Page mainPage)
        {
            InitializeComponent();


            MainPage = mainPage;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}