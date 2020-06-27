using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroDetalle_Pedido_Suplidor.Models
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "El campo Descripcion no puede estar vacío.")]
        [MinLength(10, ErrorMessage = "La Descripcion bebe tener minimo (10 caractere).")]
        [MaxLength(100, ErrorMessage = "La Descripcion debe tener Maximo (100 caracteres).")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        [Range(1, 100000, ErrorMessage = "El rango es de 1 a 100000")]
        public decimal Costo { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        [Range(1, 100000, ErrorMessage = "El rango es de 1 a 100000")]
        public int Inventario { get; set; }

        public Producto()
        {
            ProductoId = 0;
            Descripcion = string.Empty;
            Costo = 0;
            Inventario = 0;
        }

        public Producto(int productoId, string descripcion, decimal costo, int inventario)
        {
            this.ProductoId = productoId;
            this.Descripcion = descripcion;
            this.Costo = costo;
            this.Inventario = inventario;
        }
    }
}
