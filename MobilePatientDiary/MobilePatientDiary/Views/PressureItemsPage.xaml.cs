using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MobilePatientDiary.Models;
using MobilePatientDiary.Views;
using MobilePatientDiary.ViewModels;

namespace MobilePatientDiary.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PressureItemsPage : ContentPage
	{
        PressureItemsViewModel viewModel;

		public PressureItemsPage ()
		{
			InitializeComponent ();

            BindingContext = viewModel = new PressureItemsViewModel();
		}

        async void OnPressureItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var pressureItem = args.SelectedItem as PressureItem;
            if (pressureItem == null)
                return;

            await Navigation.PushAsync(new PressureItemDetailPage(new PressureItemDetailViewModel(pressureItem)));

            // Manually deselect item.
            PressureItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewPressureItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.PressureItems.Count == 0)
            {
                viewModel.LoadItemsCommand.Execute(null);
            }
        }
    }
}