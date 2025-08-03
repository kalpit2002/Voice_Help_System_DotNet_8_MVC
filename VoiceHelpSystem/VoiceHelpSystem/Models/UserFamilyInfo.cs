using System.ComponentModel.DataAnnotations;

namespace VoiceHelpSystem.Models
{
    public class UserFamilyInfo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Required]
        public string BloodGroup { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        public string Sugar { get; set; } = string.Empty;

        [Required]
        public string MedicationAllergy { get; set; } = string.Empty;

        [Required]
        public string HealthInsurance { get; set; } = string.Empty;
    }
}
