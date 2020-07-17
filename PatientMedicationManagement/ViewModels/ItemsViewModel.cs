using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using PatientMedicationManagement.Models;
using PatientMedicationManagement.Views;

namespace PatientMedicationManagement.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<MedicationModel> MedicineItems { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";
            MedicineItems = new ObservableCollection<MedicationModel>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, MedicationModel>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as MedicationModel;
                MedicineItems.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
        }
        
        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                MedicineItems.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    MedicineItems.Add(item);
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