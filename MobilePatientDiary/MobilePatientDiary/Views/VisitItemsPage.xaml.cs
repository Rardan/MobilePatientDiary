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
	public partial class VisitItemsPage : ContentPage
	{
        VisitItemsViewModel viewModel;

		public VisitItemsPage ()
		{
			InitializeComponent ();

            BindingContext = viewModel = new VisitItemsViewModel();
		}

        async void OnVisitItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var visitItem = args.SelectedItem as VisitItem;
            if (visitItem == null)
                return;

            await Navigation.PushAsync(new VisitItemDetailPage(new VisitItemDetailViewModel(visitItem)));

            VisitItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewVisitItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if(viewModel.VisitItems.Count==0)
            {
                viewModel.LoadItemsCommand.Execute(null);
            }
        }
    }
}