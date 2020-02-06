namespace Kalinkin.MyTog.Mobile
{
    public interface IAuthenticationService
    {
        void AuthenticateAsync();
        void Validate();
    }
}