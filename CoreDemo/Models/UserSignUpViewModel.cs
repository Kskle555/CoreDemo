using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Models
{
    public class UserSignUpViewModel
    {
        [Display(Name ="Ad Soyad")]
        [Required(ErrorMessage ="Lütfen Ad Soyad")]
        public string NameSurname { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Lütfen Şifre")]
        public string Password { get; set; }

        [Display(Name = "Şifre Tekrar")]
        [Compare("Password",ErrorMessage ="Şifreler Uyuşmuyor!")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Mail adresi")]
        [Required(ErrorMessage = "Lütfen Mail")]
        public string Email { get; set; }

        [Display(Name = "Kullanıcı adı")]
        [Required(ErrorMessage = "Lütfen Kullanıcı Adı")]
        public string UserName { get; set; }

    }
   
}
