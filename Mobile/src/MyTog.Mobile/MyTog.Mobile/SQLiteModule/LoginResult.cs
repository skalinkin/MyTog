using SQLite;

namespace Kalinkin.MyTog.Mobile.SQLiteModule
{
    public class LoginResult
    {
        [PrimaryKey] [AutoIncrement] public int ID { get; set; }
        public string IdentityToken { get; set; }
        public string AccessToken { get; set; }
    }
}