using MobilePatientDiary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePatientDiary.ViewModels
{
    public class VisitItemDetailViewModel : BaseViewModel
    {
        public VisitItem VisitItem { get; set; }
        public VisitItemDetailViewModel(VisitItem visitItem = null)
        {
            Title = visitItem?.MedicalSpeciality + " " + visitItem?.Date.ToString();
            VisitItem = visitItem;
        }
    }
}
