using RegistroDetalle_Pedido_Suplidor.DaLL;
using RegistroDetalle_Pedido_Suplidor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RegistroDetalle_Pedido_Suplidor.BLL
{
    public class ProductoBLL
    {
        public static Producto Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Producto productos;

            try
            {
                productos = contexto.Productos.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return productos;

        }
        public static List<Producto> GetList(Expression<Func<Producto, bool>> producto)
        {
            List<Producto> lista = new List<Producto>();
            Contexto db = new Contexto();

            try
            {
                lista = db.Productos.Where(producto).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                db.Dispose();
            }

            return lista;
        }
    }
}
