using System;
namespace PatientMedicationManagement.Models
{
    public class MedicationModel
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string Description { get; set; }
        public string ImgPath { get; set; }
        public string VoicePath { get; set; }
        public int UserId { get; set; }

    }
}
