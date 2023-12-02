using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SQLite;
using System.Globalization;
using System.Data.Common;

namespace MauiApp5
{
    class MySQLiteDatabase
    {
        private SQLiteConnection dbConnection;
        public const string DB_FILENAME = "Hiking_trip.db3";
        public const SQLiteOpenFlags FLAGS = SQLiteOpenFlags.ReadWrite |
                                             SQLiteOpenFlags.Create |
                                             SQLiteOpenFlags.SharedCache;
        public string dbPath = "";

        public const string PATIENT_TABLE = "HikingTrip";
        public const string ID_COL = "_id";
        public const string NAME_COL = "NameofTrip";
        public const string DISTANCE_COL = "Distance (Km)";
        public const string ELEVATION_COL = "ELevation (Meter)";
        public const string DATE_COL = "Date";
        public const string PARKINGAVAILABLE_COL = "ParkingAvailable";
        public const string LEVEL_COL = "Level";
        public const string LOCATON_COL = "Location";
        public const string TD_COL = "Technical Difficulty";
        public const string DESCRIPTION_COL = "Description";

        public MySQLiteDatabase()
        {
            init();
        }
        public void init()
        {
            dbPath = System.IO.Path.Combine(FileSystem.AppDataDirectory, DB_FILENAME);
            dbConnection = new SQLiteConnection(dbPath);
            dbConnection.CreateTable<Hike>();
        }
        public int insertHike(Hike p)
        {
            return dbConnection.Insert(p);
        }
        public ObservableCollection<Hike> loadHike()
        {
            return (new ObservableCollection<Hike>(dbConnection.Table<Hike>().ToList()));
        }

    }
}
