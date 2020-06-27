using Microsoft.EntityFrameworkCore;
using RegistroDetalle_Pedido_Suplidor.DaLL;
using RegistroDetalle_Pedido_Suplidor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RegistroDetalle_Pedido_Suplidor.BLL
{
    public class OrdenBLL
    {
        public static bool Guardar(Ordene ordene)
        {
            if (!Existe(ordene.OrdenId))//si no existe insertamos
                return Insertar(ordene);
            else
                return Modificar(ordene);

        }

        private static bool Insertar(Ordene ordene)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {

                //le sumamos la cantidad de productos adquiridos al inventario del producto
                foreach (var item in ordene.OrdenDetalles)
                {
                    var auxOrden = contexto.Productos.Find(item.ProductoId);
                    if (auxOrden != null)
                    {
                        auxOrden.Inventario += item.Cantidad;
                    }
                }
                contexto.Ordenes.Add(ordene);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;

            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }


        private static bool Modificar(Ordene ordene)
        {
            bool paso = false;
            var AuxAnterior = Buscar(ordene.OrdenId);
            Contexto contexto = new Contexto();

            try
            {
                //aqui borro del detalle y disminuyo el producto devuelto en inventario
                foreach (var item in AuxAnterior.OrdenDetalles)
                {
                    var auxProducto = contexto.Productos.Find(item.ProductoId);
                    if (!ordene.OrdenDetalles.Exists(d => d.OrdenDetalleId == item.OrdenDetalleId))
                    {
                        if (auxProducto != null)
                        {
                            auxProducto.Inventario -= item.Cantidad;
                        }

                        contexto.Entry(item).State = EntityState.Deleted;
                    }

                }

                //aqui agrego lo nuevo al detalle
                foreach (var item in ordene.OrdenDetalles)
                {
                    var auxProducto = contexto.Productos.Find(item.ProductoId);
                    if (item.OrdenDetalleId == 0)
                    {
                        contexto.Entry(item).State = EntityState.Added;
                        if (auxProducto != null)
                        {
                            auxProducto.Inventario += item.Cantidad;
                        }

                    }
                    else
                        contexto.Entry(item).State = EntityState.Modified;
                }


                contexto.Entry(ordene).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static Ordene Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Ordene ordenes;

            try
            {
                ordenes = contexto.Ordenes.Where(o => o.OrdenId == id).Include(d => d.OrdenDetalles).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return ordenes;

        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            var Anterior = Buscar(id);
            Contexto contexto = new Contexto();

            try
            {
                if (Existe(id))
                {
                    //aqui le resto las cantidades correspondientes a los producto
                    foreach (var item in Anterior.OrdenDetalles)
                    {
                        var auxProducto = contexto.Productos.Find(item.ProductoId);
                        if (auxProducto != null)
                        {
                            auxProducto.Inventario -= item.Cantidad;
                        }
                    }

                    //aqui remueve la entidad
                    var auxOrden = contexto.Ordenes.Find(id);
                    if (auxOrden != null)
                    {
                        contexto.Ordenes.Remove(auxOrden);
                        paso = contexto.SaveChanges() > 0;
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static List<Ordene> GetList(Expression<Func<Ordene, bool>> expression)
        {
            List<Ordene> lista = new List<Ordene>();
            Contexto db = new Contexto();

            try
            {
                lista = db.Ordenes.Where(expression).ToList();
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

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Ordenes.Any(o => o.OrdenId == id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;

        }
    }
}
