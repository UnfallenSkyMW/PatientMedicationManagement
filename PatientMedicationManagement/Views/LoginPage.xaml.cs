using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.ComponentModel;
using Xamarin.Forms.Xaml;
using PatientMedicationManagement.Models;

namespace PatientMedicationManagement.Views
{
    
    public partial class LoginPage : ContentPage
    {

        public LoginModel loginM { get; set; }
        public LoginPage()
        {
            InitializeComponent();
            loginM = new LoginModel
            {
                UserName = "TestUser",
                Password = "1234"
            };

            BindingContext = this;
        }
        async void login_Clicked(object sender, EventArgs e)
        {

            //await Navigation.PushAsync(new MainPage());
            //await Navigation.PopModalAsync();
            //await Navigation.Po
            await Navigation.PushModalAsync(new MainPage("Test user"));
        }      
    }

}
