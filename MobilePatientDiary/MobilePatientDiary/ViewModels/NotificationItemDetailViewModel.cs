using MobilePatientDiary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePatientDiary.ViewModels
{
    public class NotificationItemDetailViewModel : BaseViewModel
    {
        public NotificationItem NotificationItem { get; set; }
        public NotificationItemDetailViewModel(NotificationItem notificationItem = null)
        {
            Title = notificationItem?.Time.ToString() + " " + notificationItem?.MedicineName + " " + notificationItem?.MedicineDose.ToString();
            NotificationItem = notificationItem;
        }
    }
}
