namespace Kalinkin.MyTog.Mobile
{
    public interface IApplicationMode
    {
        void SetApplication(App application);
        void HandleOnStart();
        void HandleOnResume();
        void HandleOnSleep();
    }
}