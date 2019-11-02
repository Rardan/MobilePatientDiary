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
	public partial class GlucoseItemsPage : ContentPage
	{
        GlucoseItemsViewModel viewModel;

		public GlucoseItemsPage ()
		{
			InitializeComponent ();

            BindingContext = viewModel = new GlucoseItemsViewModel();
		}

        async void OnGlucoseItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var glucoseItem = args.SelectedItem as GlucoseItem;
            if (glucoseItem == null)
                return;

            await Navigation.PushAsync(new GlucoseItemDetailPage(new GlucoseItemDetailViewModel(glucoseItem)));

            // Manually deselect item
            GlucoseItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewGlucoseItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if(viewModel.GlucoseItems.Count == 0)
            {
                viewModel.LoadItemsCommand.Execute(null);
            }
        }
    }
}