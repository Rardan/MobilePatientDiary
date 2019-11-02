using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePatientDiary.Models
{
    public class GlucoseItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
    }
}
