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
	public partial class NewGlucoseItemPage : ContentPage
	{
        public GlucoseItem GlucoseItem { get; set; }

        public NewGlucoseItemPage ()
		{
			InitializeComponent ();

            GlucoseItem = new GlucoseItem
            {
                Id = -1,
                Date = DateTime.Now,
                Amount = 0
            };

            BindingContext = this;
		}

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddGlucoseItem", GlucoseItem);
            await Navigation.PopModalAsync();
        }
    }
}