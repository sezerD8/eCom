using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EntityLayer.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        [Display(Name = "Ad")]
        [StringLength(50, ErrorMessage = ("Maksimum 50 karakter giriniz!"))]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        [Display(Name = "Açıklama")]
        [StringLength(600, ErrorMessage = ("Maksimum 600 karakter giriniz!"))]
        public string Description{ get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        [Display(Name = "Fiyat")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        [Display(Name = "Eski Fiyat")]
        public decimal OldPrice { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        [Display(Name = "Stok")]
        public int Stock{ get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        [Display(Name = "Popüler")]
        public bool Popular { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        [Display(Name = "Onay")]
        public bool isApproved { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        [Display(Name = "Resim")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        [Display(Name = "Kategori")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<Cart> Cart { get; set; }
        public virtual List<Sales> Sales { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        [Display(Name = "Marka")]
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }


        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        [Display(Name = "Beden")]
        public int SizeId { get; set; }
        public virtual Size Size { get; set; }


        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        [Display(Name = "Cinsiyet")]
        public int GenderId { get; set; }
        public virtual Gender Gender { get; set; }


    }
}
