using System;
using PatientMedicationManagement.ViewModels;
using PatientMedicationManagement.Views;
using Xamarin.Forms;

namespace PatientMedicationManagement.Models
{
    public class LoginModel : BaseViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        

    }
}
