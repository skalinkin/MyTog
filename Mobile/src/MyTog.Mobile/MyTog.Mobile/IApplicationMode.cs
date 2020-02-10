namespace Kalinkin.MyTog.Mobile
{
    public interface IApplicationMode
    {
        void SetApplication(App App);
        void HandleOnStart();
        void HandleOnResume();
        void HandleOnSleep();
    }
}