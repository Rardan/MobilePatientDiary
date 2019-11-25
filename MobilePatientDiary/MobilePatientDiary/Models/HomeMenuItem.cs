using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePatientDiary.Models
{
    public enum MenuItemType
    {
        Pressure,
        Glucose,
        Notification,
        Visit,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
