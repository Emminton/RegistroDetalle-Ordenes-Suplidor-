using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroDetalle_Pedido_Suplidor.BLL;
using RegistroDetalle_Pedido_Suplidor.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroDetalle_Pedido_Suplidor.BLL.Tests
{
    [TestClass()]
    public class ProductoBLLTests
    {
        [TestMethod()]
        public void BuscarTest()
        {
            Producto producto = new Producto();
            producto = ProductoBLL.Buscar(1);
            Assert.IsNotNull(producto);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var lista = new List<Producto>();
            lista = ProductoBLL.GetList(p => true);
            Assert.IsNotNull(lista);
        }
    }
}