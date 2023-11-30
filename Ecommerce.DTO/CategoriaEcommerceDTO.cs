using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class CategoriaEcommerceDTO
    {
        public int IdCategoriaEcommerce { get; set; }
        [Required(ErrorMessage = "Ingrese Nombre")]

        public string? Nombre { get; set; }
    }
}
