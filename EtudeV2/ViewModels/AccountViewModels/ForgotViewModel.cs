using System.ComponentModel.DataAnnotations;

namespace EtudeV2.ViewModels.AccountViewModels
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}