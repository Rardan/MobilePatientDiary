using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePatientDiary.Models
{
    public class VisitItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string MedicalSpeciality { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Details { get; set; }
        public bool IsSended { get; set; }
    }
}
