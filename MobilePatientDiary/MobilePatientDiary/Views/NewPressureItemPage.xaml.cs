using MobilePatientDiary.Models;
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
    public partial class NewPressureItemPage : ContentPage
    {
        public PressureItem PressureItem { get; set; }

        public NewPressureItemPage()
        {
            InitializeComponent();

            PressureItem = new PressureItem
            {
                Id = -1,
                Date = DateTime.Now,
                SystolicPressure = 0,
                DiastolicPressure = 0,
                Pulse = 0
            };

            BindingContext = this;
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddPressureItem", PressureItem);
            await Navigation.PopModalAsync();
        }
    }
}