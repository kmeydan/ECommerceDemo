using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ECommerceWebUI.Models.ViewModels.HomeViewModels.ViewModel
{
	public class RegisterViewModel
	{
        [Required]
        public string Name { get; set; }
		
		[Required]
        [EmailAddress(ErrorMessage ="Eksik E Mail Girdiniz.")]
		public string Email { get; set; }
        [Required(ErrorMessage ="Boş Geçilmez")]
        public string Password { get; set; }
        [Required(ErrorMessage ="Boş Geçilmez")]
        [Compare("Password",ErrorMessage ="Parolalar Eşleşmiyor")]
        public string RePassword { get; set; }
        [Phone(ErrorMessage ="Doğru telefon numarası giriniz.")]
        public string PhoneNumber { get; set; }
        public bool GizlilikSozlesmesi { get; set; }
        public bool KVKK { get; set; }
    }
}
