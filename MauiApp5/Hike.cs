using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp5
{
    [Table("Hike")]
    public class Hike
    {
        [PrimaryKey, AutoIncrement]
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string Length { get; set; }
        public DateTime Date { get; set; }
        public string ParkingAvailable { get; set; }
        public string Level { get; set; }
        public string Location { get; set; }
        public string Descriptions { get; set; }
        public Hike() { }
        public Hike(int patientId, string nameofTrip, string length, DateTime date, string parkingAvailable,
            string level, string location, string descriptions)
        {
            PatientId = patientId;
            PatientName = nameofTrip;
            Length = length;
            Date = date;
            Level = level;
            ParkingAvailable = parkingAvailable;
            Location = location;
            Descriptions = descriptions;

        }
    }
}