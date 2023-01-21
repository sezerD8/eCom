using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xunit.Abstractions;

namespace EntityLayer.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Bu alan boş bırakılamaz!")]
        [Display(Name = "Ad")]
        [StringLength(50, ErrorMessage = ("Maksimum 50 karakter giriniz!"))]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        [Display(Name = "Soyad")]
        [StringLength(50, ErrorMessage = ("Maksimum 50 karakter giriniz!"))]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        [Display(Name = "E-Mail")]
        [StringLength(50, ErrorMessage = ("Maksimum 50 karakter giriniz!"))]
        [EmailAddress(ErrorMessage = "Mail formatı uygun değildir!")]
        public string Email{ get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        [Display(Name = "Kullanıcı Adı")]
        [StringLength(20, ErrorMessage = ("Maksimum 20 karakter giriniz!"))]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        [Display(Name = "Şifre")]
        [StringLength(20, ErrorMessage = ("Maksimum 20 karakter giriniz!"))]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        [Display(Name = "Şifre")]
        [StringLength(20, ErrorMessage = ("Maksimum 20 karakter giriniz!"))]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifreleriniz uyuşmuyor.")]
        public string RePassword{ get; set; }

        [StringLength(20, ErrorMessage = ("Maksimum 10 karakter giriniz!"))]
        public string Role{ get; set; }
    }
}
