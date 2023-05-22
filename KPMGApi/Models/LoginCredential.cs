using System.ComponentModel.DataAnnotations;

namespace KPMGAssessmentAPI.Models
{
    public class LoginCredential
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        [MaxLength(14)]
        public string Password { get; set; }
    }
}
