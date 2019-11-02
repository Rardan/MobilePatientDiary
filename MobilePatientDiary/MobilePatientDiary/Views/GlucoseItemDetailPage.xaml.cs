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
    public partial class GlucoseItemDetailPage : ContentPage
    {
        GlucoseItemDetailViewModel viewModel;

        public GlucoseItemDetailPage(GlucoseItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public GlucoseItemDetailPage()
        {
            InitializeComponent();

            var glucoseItem = new GlucoseItem
            {
                Date = DateTime.MinValue,
                Amount = 0
            };

            viewModel = new GlucoseItemDetailViewModel(glucoseItem);
            BindingContext = viewModel;
        }
    }
}