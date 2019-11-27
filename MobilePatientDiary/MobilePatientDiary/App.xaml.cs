using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobilePatientDiary.Views;
using MobilePatientDiary.Data;
using System.IO;
using System.Threading.Tasks;
using MobilePatientDiary.Services;
using MobilePatientDiary.Models;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MobilePatientDiary
{
    public partial class App : Application
    {
        static AppDatabase database;
        INotificationManager notificationManager;

        public static AppDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new AppDatabase(
                        Path.Combine(Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData),
                            "Diary.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            notificationManager = DependencyService.Get<INotificationManager>();

            MainPage = new MainPage();

            Task.Run(async () => await Notifications());
            Task.Run(async () => await Visits());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        async Task Notifications()
        {
            while (true)
            {
                DateTime dateTime = DateTime.Now;
                var notifications = await Database.GetNotificationItemsAsync();
                foreach (var item in notifications)
                {
                    if (item.Time.Hours == dateTime.Hour &&
                        item.Time.Minutes == dateTime.Minute &&
                        item.Time.Seconds == dateTime.Second &&
                        item.Time.Milliseconds == dateTime.Millisecond)
                    {
                        if (item.IsSended == false)
                        {
                            string title = $"Przypomnienie o lekach";
                            string message = $"{item.MedicineName} – {item.MedicineDose} tabletek";
                            notificationManager.ScheduleNotification(title, message);
                            item.IsSended = true;
                            await Task.Delay(1);
                        }
                    }
                    else
                    {
                        item.IsSended = false;
                    }
                }
            }
        }

        async Task Visits()
        {
            while (true)
            {
                DateTime dateTime = DateTime.Now;
                var visits = await Database.GetVisitItemsAsync();
                foreach (var item in visits)
                {
                    if (item.Date.Year == dateTime.Year &&
                        item.Date.Month == dateTime.Month &&
                        item.Date.Day == dateTime.Day &&
                        item.Date.Hour == dateTime.Hour + 1 &&
                        item.Date.Minute == dateTime.Minute &&
                        item.Date.Second == dateTime.Second &&
                        item.Date.Millisecond == dateTime.Millisecond)
                    {
                        if (item.IsSended == false)
                        {
                            string title = "Wizyta u lekarza";
                            string message = $"Masz wizytę u {item.MedicalSpeciality}, o godzinie {item.Date.ToShortTimeString()}, w {item.Location}";
                            notificationManager.ScheduleNotification(title, message);
                            item.IsSended = true;
                            await Task.Delay(1);
                        }
                    }
                }
            }
        }
    }
}
