using RegistroDetalle_Pedido_Suplidor.DaLL;
using RegistroDetalle_Pedido_Suplidor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RegistroDetalle_Pedido_Suplidor.BLL
{
    public class SuplidorBLL
    {
        public static List<Suplidore> GetList(Expression<Func<Suplidore, bool>> expression)
        {
            List<Suplidore> lista = new List<Suplidore>();
            Contexto db = new Contexto();

            try
            {
                lista = db.Suplidores.Where(expression).ToList();
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
