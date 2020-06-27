using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroDetalle_Pedido_Suplidor.Models
{
    public class Suplidore
    {
        [Key]
        public int SuplidorId { get; set; }

        [Required(ErrorMessage = "No debe de estar Vacío el campo 'Nombre'")]
        [MinLength(3, ErrorMessage = "El Nombres es muy corto.")]
        [MaxLength(50, ErrorMessage = "El nombre debe contener menos de 50 caracteres.")]
        public string Nombre { get; set; }

        public Suplidore()
        {
            SuplidorId = 0;
            Nombre = string.Empty;
        }

        public Suplidore(int suplidorId, string nombre)
        {
            this.SuplidorId = suplidorId;
            this.Nombre = nombre;
        }
    }
}
