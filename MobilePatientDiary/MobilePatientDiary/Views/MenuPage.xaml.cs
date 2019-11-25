using MobilePatientDiary.Models;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobilePatientDiary.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.About, Title="O aplikacji" },
                new HomeMenuItem {Id = MenuItemType.Pressure, Title="Ciśnienie" },
                new HomeMenuItem {Id = MenuItemType.Glucose, Title="Cukier" },
                new HomeMenuItem{Id = MenuItemType.Notification, Title="Przypomnienia o lekach" },
                new HomeMenuItem{Id = MenuItemType.Visit, Title="Wizyty u lekarza"}
           //     new HomeMenuItem {Id = MenuItemType.Browse, Title="Browse" },
                
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}