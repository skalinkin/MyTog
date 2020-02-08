using System;

namespace Kalinkin.MyTog.Mobile.SQLiteComponent
{
    public class AccessTokenLifetimeRecord:IRecord
    {
        public string AccessToken { get; set; }
        public DateTime AccessTokenExpiration { get; set; }
        public DateTime AuthenticationTime { get; set; }
        public string IdentityToken { get; set; }
        public string RefreshToken { get; set; }
        public int Id { get; set; }
    }
}