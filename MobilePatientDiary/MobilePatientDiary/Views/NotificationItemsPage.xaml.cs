using MobilePatientDiary.Models;
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
    public partial class NotificationItemsPage : ContentPage
    {
        NotificationItemsViewModel viewModel;

        public NotificationItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new NotificationItemsViewModel();
        }

        async void OnNotificationItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var notificationItem = args.SelectedItem as NotificationItem;
            if (notificationItem == null)
                return;

            await Navigation.PushAsync(new NotificationItemDetailPage(new NotificationItemDetailViewModel(notificationItem)));
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewNotificationItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.NotificationItems.Count==0)
            {
                viewModel.LoadItemsCommand.Execute(null);
            }
        }
    }
}