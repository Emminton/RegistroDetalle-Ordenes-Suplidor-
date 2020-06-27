using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroDetalle_Pedido_Suplidor.BLL;
using RegistroDetalle_Pedido_Suplidor.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RegistroDetalle_Pedido_Suplidor.BLL.Tests
{
    [TestClass()]
    public class OrdenBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            Ordene orden = new Ordene();
            orden.OrdenId = 0;
            orden.SuplidorId = 1;
            orden.Fecha = DateTime.Now;
            orden.Monto = 250;
            orden.OrdenDetalles.Add(new OrdenesDetalle
            {
                OrdenDetalleId = 0,
                OrdenId = 0,
                ProductoId = 1,
                Costo = 250,
                Cantidad = 1
            });
           
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Ordene ordene = new Ordene();
            ordene = OrdenBLL.Buscar(1);
            Assert.IsNotNull(ordene);
        }

        [TestMethod()]
        public void EliminarTest()

        {
            bool eliminar = OrdenBLL.Eliminar(1);
            Assert.AreEqual(eliminar, true);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var lista = new List<Ordene>();
            lista = OrdenBLL.GetList(p => true);

            Assert.IsNotNull(lista);
        }

        [TestMethod()]
        public void ExisteTest()
        {
            bool existe = OrdenBLL.Existe(1);
            Assert.AreEqual(existe, false);
        }
    }
}