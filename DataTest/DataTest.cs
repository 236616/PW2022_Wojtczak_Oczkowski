using Data;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;


namespace Tests.DataTests
{
    [TestClass]
    public class DataTest
    {
        [TestMethod]
        public void BoxTest()
        {
            LogicAPI api = LogicAPI.CreateBox(100, 200);
            Assert.AreEqual((int)Box.width, 100);
            Assert.AreEqual((int)Box.height, 200);
        }


        [TestMethod]
        public void InBoxTest()
        {
            LogicAPI api = LogicAPI.CreateBox(150, 150);
            api.SummonBalls(1);
            List<DataAPI> balls = api.GetOldBalls();

            Assert.IsTrue(balls[0].XPosition <= 150);
            Assert.IsTrue(balls[0].YPosition <= 150);
        }


        [TestMethod]
        public void MoveTest()
        {
            LogicAPI api = LogicAPI.CreateBox(150, 150);
            api.isMoving = true;
            api.SummonBalls(1);
            List<DataAPI> balls = api.GetOldBalls();

            balls[0].XPosition = 50;
            Assert.AreEqual(balls[0].XPosition, 50);
            balls[0].YPosition = 10;
            Assert.AreEqual(balls[0].YPosition, 10);
            balls[0].vx = 15;
            Assert.AreEqual(balls[0].vx, 15);
            balls[0].vy = 60;
            Assert.AreEqual(balls[0].vy, 60);
            balls[0].move();
            Assert.AreEqual(balls[0].XPosition, 65);
            Assert.AreEqual(balls[0].YPosition, 70);
        }
    }
}
