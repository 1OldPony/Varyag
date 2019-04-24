using System.ComponentModel.DataAnnotations;

namespace Varyag.Models.ViewModels
{
    public class LogInViewModel
    {
        [Required]
        [Display(Name = "Имя пользователя")]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
