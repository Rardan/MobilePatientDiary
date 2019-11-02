using MobilePatientDiary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePatientDiary.ViewModels
{
    public class GlucoseItemDetailViewModel : BaseViewModel
    {
        public GlucoseItem GlucoseItem { get; set; }
        public GlucoseItemDetailViewModel(GlucoseItem glucoseItem = null)
        {
            Title = glucoseItem?.Amount.ToString() + " " + glucoseItem?.Date.ToString();
            GlucoseItem = glucoseItem;
        }
    }
}
