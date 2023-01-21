using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        [Display(Name = "Ad")]
        [StringLength(50,ErrorMessage = ("Maksimum 50 karakter giriniz!"))]
        public string Name { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        [Display(Name = "Açıklama")]
        [StringLength(50, ErrorMessage = ("Maksimum 50 karakter giriniz!"))]
        public string Description { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
