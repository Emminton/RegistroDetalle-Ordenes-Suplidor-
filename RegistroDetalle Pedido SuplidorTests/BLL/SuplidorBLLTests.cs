using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroDetalle_Pedido_Suplidor.BLL;
using RegistroDetalle_Pedido_Suplidor.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroDetalle_Pedido_Suplidor.BLL.Tests
{
    [TestClass()]
    public class SuplidorBLLTests
    {
        [TestMethod()]
        public void GetListTest()
        {
            var lista = new List<Suplidore>();
            lista = SuplidorBLL.GetList(p => true);

            Assert.IsNotNull(lista);
        }
    }
}