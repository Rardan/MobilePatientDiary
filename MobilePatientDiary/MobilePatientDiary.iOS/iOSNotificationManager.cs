using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using MobilePatientDiary.Models;
using MobilePatientDiary.Services;
using UIKit;
using UserNotifications;
using Xamarin.Forms;

[assembly: Dependency(typeof(MobilePatientDiary.iOS.iOSNotificationManager))]
namespace MobilePatientDiary.iOS
{
    public class iOSNotificationManager : INotificationManager
    {
        int messageId = -1;
        bool hasNotificationPermision;
        public event EventHandler NotificationReceived;

        public void Initialize()
        {
            UNUserNotificationCenter.Current.RequestAuthorization(UNAuthorizationOptions.Alert, (approved, err) =>
            {
                hasNotificationPermision = approved;
            });
        }

        public int ScheduleNotification(string title, string message)
        {
            if(!hasNotificationPermision)
            {
                return -1;
            }

            messageId++;

            var content = new UNMutableNotificationContent()
            {
                Title = title,
                Subtitle = "",
                Body = message,
                Badge = 1
            };

            var trigger = UNTimeIntervalNotificationTrigger.CreateTrigger(0.25, false);

            var request = UNNotificationRequest.FromIdentifier(messageId.ToString(), content, trigger);
            UNUserNotificationCenter.Current.AddNotificationRequest(request, (err) =>
            {
                if (err != null)
                {
                    throw new Exception($"error: {err}");
                }
            });

            return messageId;
        }

        public void ReceiveNotification(string title, string message)
        {
            var args = new NotificationEventArgs()
            {
                Title = title,
                Message = message
            };
            NotificationReceived?.Invoke(null, args);
        }
    }
}