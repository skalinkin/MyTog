using System;
using SQLite;

namespace Kalinkin.MyTog.Mobile.Domain
{
    internal class ApplicationModeRecord
    {
        [PrimaryKey, Unique, AutoIncrement]
        public int Id { get; set; }
        public string Mode { get; set; }
        public DateTime SetTime { get; set; }
    }
}