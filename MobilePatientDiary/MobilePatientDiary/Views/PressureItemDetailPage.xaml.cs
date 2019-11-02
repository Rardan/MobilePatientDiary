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
    public partial class PressureItemDetailPage : ContentPage
    {
        PressureItemDetailViewModel viewModel;

        public PressureItemDetailPage(PressureItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public PressureItemDetailPage()
        {
            InitializeComponent();

            var pressureItem = new PressureItem
            {
                Date = DateTime.MinValue,
                SystolicPressure = 0,
                DiastolicPressure = 0,
                Pulse = 0
            };

            viewModel = new PressureItemDetailViewModel(pressureItem);
            BindingContext = viewModel;
        }

        async void DeleteItem_Clicked(object sender, EventArgs args)
        {
            MessagingCenter.Send(this, "DeletePressureItem", viewModel.PressureItem);
            await Navigation.PopToRootAsync();
        }
    }
}