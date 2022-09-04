using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage="Lütfen rol adın giriniz.")]
        public string name { get; set; }
    }
}
