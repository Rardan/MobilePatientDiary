using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePatientDiary.Models
{
    public class NotificationItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public TimeSpan Time { get; set; }
        public string MedicineName { get; set; }
        public decimal MedicineDose { get; set; }
        public bool IsSended { get; set; }
    }
}
