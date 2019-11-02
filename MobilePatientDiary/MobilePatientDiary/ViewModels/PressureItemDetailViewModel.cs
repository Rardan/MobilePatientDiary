using MobilePatientDiary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePatientDiary.ViewModels
{
    public class PressureItemDetailViewModel : BaseViewModel
    {
        public PressureItem PressureItem { get; set; }
        public PressureItemDetailViewModel(PressureItem pressureItem = null)
        {
            Title = pressureItem?.Id.ToString() + " " + pressureItem?.Date.ToString();
            PressureItem = pressureItem;
        }
    }
}
