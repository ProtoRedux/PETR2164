using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MobileAppDev.Models
{
    public class Note
    {
        //using SQLite to store the not objects in a database. every instance will be given an ID which is its priamary key and the ID will auto increment.
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
