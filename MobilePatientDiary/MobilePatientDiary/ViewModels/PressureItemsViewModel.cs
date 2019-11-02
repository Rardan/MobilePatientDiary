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
    class PressureItemsViewModel : BaseViewModel
    {
        public ObservableCollection<PressureItem> PressureItems { get; set; }
        public Command LoadItemsCommand { get; set; }

        public PressureItemsViewModel()
        {
            Title = "Ciśnienie i puls";
            PressureItems = new ObservableCollection<PressureItem>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewPressureItemPage, PressureItem>(this, "AddPressureItem", async (obj, item) =>
            {
                var newItem = item as PressureItem;
                PressureItems.Add(newItem);
                await App.Database.SavePressureItemAsync(newItem);
            });

            MessagingCenter.Subscribe<PressureItemDetailPage, PressureItem>(this, "DeletePressureItem", async (obj, i) =>
            {
                var oldItem = i as PressureItem;
                PressureItems.Remove(oldItem);
                await App.Database.DeletePressureItemAsync(oldItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                PressureItems.Clear();
                var pressureItems = await App.Database.GetPresureItemsAsync();
                foreach (var item in pressureItems)
                {
                    PressureItems.Add(item);
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
