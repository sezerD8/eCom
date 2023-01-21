using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EntityLayer.Entities
{
    public class Gender
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        [Display(Name = "Cinsiyet")]
        public string Name { get; set; }
        public virtual List<Product> Products { get; set; }

    }
}
