using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePatientDiary.Models
{
    public class PressureItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int SystolicPressure { get; set; } //skurczowe
        public int DiastolicPressure { get; set; } //rozkurczowe
        public int Pulse { get; set; }
    }
}
