using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MobileAppDev.Models
{
    public class BirdModel
    {
        //using SQLite to store the bird sighting objects in a database.
        //Every instance will be given an ID which is its primary key and the ID will auto increment.
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Species { get; set; }
        public string CommonName { get; set; }
        public string Location { get; set; }
        public DateTime DateSeen { get; set; }
        public string Notes { get; set; }
    }
}
