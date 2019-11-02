using MobilePatientDiary.Models;
using MobilePatientDiary.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobilePatientDiary.ViewModels
{
    public class GlucoseItemsViewModel : BaseViewModel
    {
        public ObservableCollection<GlucoseItem> GlucoseItems { get; set; }
        public Command LoadItemsCommand { get; set; }

        public GlucoseItemsViewModel()
        {
            Title = "Poziom cukru";
            GlucoseItems = new ObservableCollection<GlucoseItem>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewGlucoseItemPage, GlucoseItem>(this, "AddGlucoseItem", async (obj, item) =>
            {
                var newItem = item as GlucoseItem;
                GlucoseItems.Add(newItem);
                await App.Database.SaveGlucoseItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                GlucoseItems.Clear();
                var glucoseItems = await App.Database.GetGlucoseItemsAsync();
                foreach (var item in glucoseItems)
                {
                    GlucoseItems.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
