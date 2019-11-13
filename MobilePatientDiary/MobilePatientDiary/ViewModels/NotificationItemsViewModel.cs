using MobilePatientDiary.Models;
using MobilePatientDiary.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobilePatientDiary.ViewModels
{
    public class NotificationItemsViewModel : BaseViewModel
    {
        public ObservableCollection<NotificationItem> NotificationItems { get; set; }
        public Command LoadItemsCommand { get; set; }

        public NotificationItemsViewModel()
        {
            Title = "Leki";
            NotificationItems = new ObservableCollection<NotificationItem>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewNotificationItemPage, NotificationItem>(this, "AddNotificationItem", async (obj, item) =>
            {
                var newItem = item as NotificationItem;
                NotificationItems.Add(newItem);
                await App.Database.SaveNotificationItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                NotificationItems.Clear();
                var notificationItems = await App.Database.GetNotificationItemsAsync();
                foreach (var item in notificationItems)
                {
                    NotificationItems.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
