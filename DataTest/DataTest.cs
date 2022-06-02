using Data;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

using System.IO;
using System;

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

        [TestMethod]
        public void LogFileCreateTest()
        {
            DataAPI ball = DataAPI.getBall(50, 50, 0);

            Logger log = new Logger(ball);
            Console.WriteLine(Path.GetTempPath() + "LOGS\\ball0.json");
            Assert.IsFalse(File.Exists(Path.GetTempPath() + "LOGS\\ball0.json"));
        }
        [TestMethod]
        public void LoggingTest()
        {
            DataAPI ball = DataAPI.getBall(1111, 22222, 1);
            ball.vx = 420;
            ball.vy = 2137;
            Logger log = new Logger(ball);
            log.log();
            string input = File.ReadAllText(Path.GetTempPath() + "LOGS\\ball1" + "_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".json");
            Assert.AreEqual(input, "[\n  {\n    \"id\": 1,\n    \"XPosition\": 1111,\n    \"YPosition\": 22222,\n    \"Radius\": 15,\n    \"vx\": 420,\n    \"vy\": 2137,\n    \"mass\": 10.0\n  }\n]");
        }
    }
}
