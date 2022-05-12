using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.DataTests
{
    internal class DataTest
    {
        [TestMethod]
        public void BoxTest()
        {
            LogicAPI api = LogicAPI.Create(150, 100);
            Assert.AreEqual((int)Box.width, 150);
            Assert.AreEqual((int)Box.height, 100);
        }
    }
}
