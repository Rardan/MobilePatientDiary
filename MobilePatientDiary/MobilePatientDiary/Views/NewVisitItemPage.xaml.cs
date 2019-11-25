using MobilePatientDiary.Models;
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
    public partial class NewVisitItemPage : ContentPage
    {
        public VisitItem VisitItem { get; set; }
        public DateTime DateNow { get; set; }

        public NewVisitItemPage()
        {
            InitializeComponent();
            DateNow = DateTime.Now;
            VisitItem = new VisitItem
            {
                Id = -1,
                MedicalSpeciality = "",
                Date = DateTime.Now,
                Location = "",
                Details = "",
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
            VisitItem.Date = _datePicker.Date + _timePicker.Time;

            var items = await App.Database.GetVisitItemsAsync();
            string msg = "";

            foreach (var item in items)
            {
                if (item.Date.Year == VisitItem.Date.Year &&
                    item.Date.Month == VisitItem.Date.Month &&
                    item.Date.Day == VisitItem.Date.Day)
                    msg =msg + item.MedicalSpeciality + " ";
            }

            if(msg.Length > 0)
            {
                bool result = await DisplayAlert("Uwaga", "Tego dnia msz wizytę u: " + msg + "\n Na pewno chcesz ustawić nową wizytę?", "Tak", "Nie");
                if(result)
                    MessagingCenter.Send(this, "AddVisitItem", VisitItem);
            }
            else
            {
                MessagingCenter.Send(this, "AddVisitItem", VisitItem);
            }

            await Navigation.PopModalAsync();
        }

        //void _datePicker_DateSelected(object sender, DateChangedEventArgs args)
        //{
        //    VisitItem.Date = _datePicker.Date;
        //}

        //void _timePicker_PropertyChanged(object sender, PropertyChangedEventArgs args)
        //{
        //    VisitItem.Date += _timePicker.Time;
        //}
    }
}