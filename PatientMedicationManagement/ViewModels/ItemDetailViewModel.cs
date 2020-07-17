using System;

using PatientMedicationManagement.Models;

namespace PatientMedicationManagement.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public MedicationModel Item { get; set; }
        public ItemDetailViewModel(MedicationModel item = null)
        {
            Title = item?.Id;
            Item = item;
        }
    }
}
