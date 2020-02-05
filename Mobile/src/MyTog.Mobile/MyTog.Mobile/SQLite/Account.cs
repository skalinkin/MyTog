using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Kalinkin.MyTog.Mobile
{
    class Account
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }
    }
}
