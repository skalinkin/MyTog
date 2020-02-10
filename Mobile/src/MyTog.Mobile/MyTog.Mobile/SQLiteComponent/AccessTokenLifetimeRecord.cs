using System;
using SQLite;

namespace Kalinkin.MyTog.Mobile.SQLiteComponent
{
    public class AccessTokenLifetimeRecord
    {
        [PrimaryKey, Unique, AutoIncrement]
        public int Id { get; set; }
        public string AccessToken { get; set; }
        public DateTime AccessTokenExpiration { get; set; }
        public DateTime AuthenticationTime { get; set; }
        public string IdentityToken { get; set; }
        public string RefreshToken { get; set; }
    }
}