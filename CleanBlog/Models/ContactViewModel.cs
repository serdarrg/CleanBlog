using System.ComponentModel.DataAnnotations;

namespace CleanBlog.Models
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Lütfen isim giriniz.")]
        public string ContactFullName { get; set; }

        [Required(ErrorMessage ="Lütfen e-posta adresini giriniz.")]
        [DataType(DataType.EmailAddress, ErrorMessage ="Doğru bir e-posta adresi giriniz.")]
        public string ContactEmail { get; set; }

        [Required(ErrorMessage = "Lütfen telefon numarası giriniz.")]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Lütfen mesaj giriniz.")]
        [MinLength(10, ErrorMessage = "Mesaj en az 10 karakter olabilir.")]
        public string Message { get; set; }
    }
}
