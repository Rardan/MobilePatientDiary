using MobilePatientDiary.Models;
using MobilePatientDiary.Services;
using MobilePatientDiary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobilePatientDiary.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificationItemDetailPage : ContentPage
    {
        NotificationItemDetailViewModel viewModel;
        INotificationManager notificationManager;

        public NotificationItemDetailPage(NotificationItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;

            notificationManager = DependencyService.Get<INotificationManager>();
            notificationManager.NotificationReceived += (sender, eventArgs) =>
            {
                var evtData = (NotificationEventArgs)eventArgs;
            };
        }

        public NotificationItemDetailPage()
        {
            InitializeComponent();

            var notificationItem = new NotificationItem
            {
                Time = TimeSpan.MinValue,
                MedicineName = "",
                MedicineDose = 0.0M
            };

            viewModel = new NotificationItemDetailViewModel(notificationItem);
            BindingContext = viewModel;

            notificationManager = DependencyService.Get<INotificationManager>();
            notificationManager.NotificationReceived += (sender, eventArgs) =>
            {
                var evtData = (NotificationEventArgs)eventArgs;
            };
        }

        public void Button_Clicked(object sender, EventArgs e)
        {
            string title = $"Przypomnienie o lekach";
            string message = $"{viewModel.NotificationItem.MedicineName}: {viewModel.NotificationItem.MedicineDose} tabletek";
            notificationManager.ScheduleNotification(title, message);
        }
    }
}