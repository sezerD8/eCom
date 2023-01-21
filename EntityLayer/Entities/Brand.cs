using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xunit.Abstractions;

namespace EntityLayer.Entities
{
    public class Brand
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz!")]
        [Display(Name = "Marka")]
        public string Name { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
