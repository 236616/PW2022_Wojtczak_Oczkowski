using Data;
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
            LogicAPI api = LogicAPI.CreateBox(200, 200);
            api.SummonBalls(10);
            List<SBallAPI> balls = api.GetAllBalls();
            Assert.AreEqual(10, api.GetAllBalls().Count);
        }

        [TestMethod]
        public void ClearBallsTest()
        {
            LogicAPI api = LogicAPI.CreateBox(200, 200);

            api.SummonBalls(10);
            api.ClearMap();
            List<SBallAPI> balls = api.GetAllBalls();
            Assert.AreEqual(0, api.GetAllBalls().Count);
        }

        [TestMethod]
        public void SBallTest()
        {
            LogicAPI api = LogicAPI.CreateBox(200, 200);
            api.SummonBalls(1);
            List<SBallAPI> balls = api.GetAllBalls();
            balls[0].Radius = 10;
            balls[0].XPos = 20;
            balls[0].YPos = 30;

            Assert.AreEqual(balls[0].Radius, 10);
            Assert.AreEqual(balls[0].XPos, 20);
            Assert.AreEqual(balls[0].YPos, 30);
        }
    }
}