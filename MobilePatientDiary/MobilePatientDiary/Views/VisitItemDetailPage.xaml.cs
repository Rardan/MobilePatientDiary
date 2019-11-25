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
	public partial class VisitItemDetailPage : ContentPage
	{
        VisitItemDetailViewModel viewModel;

		public VisitItemDetailPage (VisitItemDetailViewModel viewModel)
		{
			InitializeComponent ();

            BindingContext = this.viewModel = viewModel;
		}

        public VisitItemDetailPage()
        {
            InitializeComponent();

            var visitItem = new VisitItem
            {
                Date = DateTime.MinValue,
                MedicalSpeciality = "",
                Location = "",
                Details = ""
            };

            viewModel = new VisitItemDetailViewModel(visitItem);
            BindingContext = viewModel;
        }

        async void DeleteItem_Clicked(object sender, EventArgs args)
        {
            MessagingCenter.Send(this, "DeleteVisitItem", viewModel.VisitItem);
            await Navigation.PopToRootAsync();
        }
    }
}