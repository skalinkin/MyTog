using SQLite;

namespace Kalinkin.MyTog.Mobile.SQLiteComponent
{
    internal class AccountRecord
    {
        [PrimaryKey] [AutoIncrement] public int ID { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }
    }
}