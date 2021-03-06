﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using PatientMedicationManagement.Models;
using PatientMedicationManagement.Views;
using PatientMedicationManagement.ViewModels;

namespace PatientMedicationManagement.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;
        public ItemsPage()
        {
          
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel() {};


            
        }
        //public ItemsPage(string username)
        //{
        //    InitializeComponent();

        //    BindingContext = viewModel = new ItemsViewModel();
        //    viewModel.UserName = username;
        //}

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var item = (MedicationModel)layout.BindingContext;
            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.MedicineItems.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}