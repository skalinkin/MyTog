namespace Kalinkin.MyTog.Mobile.Domain
{
    public class LoginResult
    {
        public int Id { get; set; }
        public string IdentityToken { get; set; }
        public string AccessToken { get; set; }
    }
}