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
    public class VisitItemsViewModel : BaseViewModel
    {
        public ObservableCollection<VisitItem> VisitItems { get; set; }
        public Command LoadItemsCommand { get; set; }

        public VisitItemsViewModel()
        {
            Title = "Wizyty";
            VisitItems = new ObservableCollection<VisitItem>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewVisitItemPage, VisitItem>(this, "AddVisitItem", async (obj, item) =>
            {
                var newItem = item as VisitItem;
                VisitItems.Add(newItem);
                await App.Database.SaveVisitItemAsync(newItem);
            });

            MessagingCenter.Subscribe<VisitItemDetailPage, VisitItem>(this, "DeleteVisitItem", async (obj, i) =>
            {
                var oldItem = i as VisitItem;
                VisitItems.Remove(oldItem);
                await App.Database.DeleteVisitItemAsync(oldItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                VisitItems.Clear();
                var visitItems = await App.Database.GetVisitItemsAsync();
                foreach (var item in visitItems)
                {
                    VisitItems.Add(item);
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
