using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroDetalle_Pedido_Suplidor.Models
{
    public class OrdenesDetalle
    {
        [Key]
        public int OrdenDetalleId { get; set; }
        public int OrdenId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal Costo { get; set; }

        public OrdenesDetalle()
        {
            OrdenDetalleId = 0;
            OrdenId = 0;
            ProductoId = 0;
            Cantidad = 0;
            Costo = 0;
        }

        public OrdenesDetalle(int ordenDetalleId, int ordenId, int productoId, int cantidad, decimal costo)
        {
            this.OrdenDetalleId = ordenDetalleId;
            this.OrdenId = ordenId;
            this.ProductoId = productoId;
            this.Cantidad = cantidad;
            this.Costo = costo;
        }
    }
}
