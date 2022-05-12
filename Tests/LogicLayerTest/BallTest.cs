using Data;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tests.DataTest
{
    [TestClass]
    public class BallTest
    {
        [TestMethod]
        public void BallConstructorTest()
        {
            LogicAPI.BallAPI ball = LogicAPI.BallAPI.CreateBall(0, 0, 1, 0, 2, 3);
            Assert.AreEqual(0, ball.XPos);
            Assert.AreEqual(1, ball.YPos);
            Assert.AreEqual(2, ball.XMove);
            Assert.AreEqual(3, ball.YMove);
            Assert.AreEqual(0, ball.GetID());
            Assert.AreEqual(0, ball.Radius);

            Assert.IsTrue(ball.XPos >= 0);
            Assert.IsTrue(ball.YPos >= 0);
            Assert.IsTrue(ball.XMove >= 0);
            Assert.IsTrue(ball.YMove >= 0);
            Assert.IsTrue(ball.GetID() >= 0);
            Assert.IsTrue(ball.Radius >= 0);
        }

    } 
}