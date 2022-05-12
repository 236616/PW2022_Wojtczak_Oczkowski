using LogicLayer;
using LogicLayer.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Tests.LogicTest
{
    [TestClass]
    public class LogicTest
    {

        [TestMethod]
        public void SummonBallsTest()
        {
            LogicAPI api = LogicAPI.CreateManager(100, 100);
            api.SummonBalls(10);
            Assert.AreEqual(10, api.GetAllBalls().Count);
        }

        [TestMethod]
        public void RemoveBallsTest()
        {
            LogicAPI api = LogicAPI.CreateManager(100, 100);

            api.SummonBalls(10);
            api.ClearMap();
            Assert.AreEqual(0, api.GetAllBalls().Count);
        }

        [TestMethod]
        public void TicKTest()
        {
            LogicAPI api = LogicAPI.CreateManager(100, 100);

            api.SummonBalls(10);
            List<LogicAPI.BallAPI> balls = api.GetAllBalls();

            int[] beginningX = new int[10];
            int[] beginningY = new int[10];
            api.DoTick();
            for (int i = 0; i < beginningX.Length; i++)
            {
                beginningX[i] = balls[i].XPosition;
                beginningY[i] = balls[i].YPosition;
            }
            api.DoTick();
            for (int i = 0; i < beginningX.Length; i++)
            {
                Assert.IsFalse(beginningX[i] != balls[i].XPosition || beginningY[i] != balls[i].YPosition);

            }
        }
    }
}