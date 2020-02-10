using System;

namespace Kalinkin.MyTog.Mobile.Domain
{
    public class AccessTokenLifetime
    {
        public int Id { get; set; }
        public string AccessToken { get; set; }
        public DateTime AccessTokenExpiration { get; set; }
        public DateTime AuthenticationTime { get; set; }
        public string IdentityToken { get; set; }
        public string RefreshToken { get; set; }
    }
}