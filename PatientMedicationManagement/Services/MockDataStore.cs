using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PatientMedicationManagement.Models;

namespace PatientMedicationManagement.Services
{
    public class MockDataStore : IDataStore<MedicationModel>
    {
        readonly List<MedicationModel> items;

        public MockDataStore()
        {
            items = new List<MedicationModel>()
            {
                new MedicationModel {
                    Name = "Medicine 01",
                    Id =Guid.NewGuid().ToString(),
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras imperdiet pretium mi sed tristique. Phasellus commodo lobortis libero id cursus. Nam ornare purus sodales arcu dapibus vestibulum. Maecenas ultricies lectus eros, vitae auctor dolor scelerisque ac. Vivamus porta felis purus, et condimentum erat pretium vel. Maecenas ac libero est. Mauris vel imperdiet risus. Nam consectetur, nibh ac ullamcorper consequat, quam ipsum condimentum nulla, sed ornare enim felis sed mi. Fusce sit amet neque ante. Sed finibus, dui in consequat convallis, risus elit commodo turpis, quis pulvinar orci dolor vitae neque. In semper finibus massa. In mollis id tellus vel aliquam. Aenean fermentum tellus magna, in dapibus est viverra eget. In lobortis felis eu est ultricies malesuada",
                    ImgPath = "https://images.squarespace-cdn.com/content/v1/5836f01fe6f2e1fa62c11f08/1530545684016-MESWBHTP8CEN76LWX5O7/ke17ZwdGBToddI8pDm48kPhE_b-FKx_EcxRx4teFEVN7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z4YTzHvnKhyp6Da-NYroOW3ZGjoBKy3azqku80C789l0k5fwC0WRNFJBIXiBeNI5fL8LmMajxsBXeYxVzkYts3ds68Ud4HgM4ArFxmxGpI5hQ/shutterstock_122547412.jpg",
                    VoicePath = "1.png",
                    UserId = 1
                    },
                new MedicationModel {
                    Name = "Medicine 02",
                    Id =Guid.NewGuid().ToString(),
                    Description = "Integer maximus tellus placerat, accumsan ligula ut, rutrum eros. Ut vel tortor at ligula ornare volutpat auctor non enim. Quisque vel velit nec tortor sollicitudin posuere. Nulla nec lacinia sem, eu posuere libero. Suspendisse eleifend tempor nunc sed imperdiet. In in pellentesque tellus. Vivamus a placerat massa.",
                    ImgPath = "https://thumbs.dreamstime.com/z/lot-colorful-medication-pills-lots-drugs-packages-scattered-multi-colored-tablets-capsules-100917226.jpg",
                    VoicePath = "2.png",
                    UserId = 1
                    },

            };
             
        }

        public async Task<bool> AddItemAsync(MedicationModel item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(MedicationModel item)
        {
            var oldItem = items.Where((MedicationModel arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((MedicationModel arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<MedicationModel> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<MedicationModel>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}