using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace TFOR_Android.Assets
{
    [Table("station_photos")]
    public class Stock
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [Column("_photo")]
        public string Photo { get; set; }
    }
    class db
    {
        public static string DataAccess ()
        {
            var output = "";
            output += "\nCreating database, if it doenst already exist";
            string dbPath = Path.Combine(
                System.Environment.GetFolderPath
                (System.Environment.SpecialFolder.Personal), "db.db3");

            var db = new SQLiteConnection(dbPath);
            db.CreateTable<Stock>();

            if (db.Table<Stock> ().Count() == 0)
            {

            }
        }
    }
}