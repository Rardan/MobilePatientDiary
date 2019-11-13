using Android.App;
using MobilePatientDiary.Models;
using MobilePatientDiary.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobilePatientDiary.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewNotificationItemPage : ContentPage
    {
        public NotificationItem NotificationItem { get; set; }

        public NewNotificationItemPage()
        {
            InitializeComponent();

            NotificationItem = new NotificationItem
            {
                Id = -1,
                Time = TimeSpan.MinValue,
                MedicineName = " ",
                MedicineDose = 0.0M,
                IsSended = false
            };

            BindingContext = this;
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddNotificationItem", NotificationItem);
            await Navigation.PopModalAsync();
        }

        private void TimePicker_PropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "Time")
            {
                NotificationItem.Time = _timePicker.Time;
            }
        }
    }
}