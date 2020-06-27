using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroDetalle_Pedido_Suplidor.Models
{
    public class Ordene
    {
        [Key]
        [Required(ErrorMessage = "El campo Id no puede estar vacío.")]
        [Range(0, 1000000, ErrorMessage = "El campo Id no puede ser menor que cero o mayor a 1000000.")]
        public int OrdenId { get; set; }

        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "El campo fecha no puede estar vacío.")]
        [DisplayFormat(DataFormatString = "{0:dd,mm, yyyy}")]
        public DateTime Fecha { get; set; }

        [Range(1, 1000000, ErrorMessage = "Debe elegir un suplidor.")]
        public int SuplidorId { get; set; }

        [Required(ErrorMessage = "El campo total no puede estar vacio.")]
        [Range(1, 100000000, ErrorMessage = "El rango es de 1 a 1000000.")]
        public decimal Monto { get; set; }

        [ForeignKey("OrdenId")]
        public virtual List<OrdenesDetalle> OrdenDetalles { get; set; }
        public Ordene()
        {
            OrdenId = 0;
            Fecha = DateTime.Now;
            SuplidorId = 0;
            Monto = 0;
            OrdenDetalles = new List<OrdenesDetalle>();
        }

        public Ordene(int ordenId, DateTime fecha, int suplidorId, decimal monto, List<OrdenesDetalle> ordenDetalles)
        {
            this.OrdenId = ordenId;
            this.Fecha = fecha;
            this.SuplidorId = suplidorId;
            this.Monto = monto;
            OrdenDetalles = ordenDetalles;
        }
    }
}
