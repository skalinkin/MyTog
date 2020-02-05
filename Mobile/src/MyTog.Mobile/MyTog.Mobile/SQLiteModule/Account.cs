using SQLite;

namespace Kalinkin.MyTog.Mobile.SQLiteModule
{
    internal class Account
    {
        [PrimaryKey] [AutoIncrement] public int ID { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }
    }
}