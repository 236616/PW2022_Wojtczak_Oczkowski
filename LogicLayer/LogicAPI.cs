using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public abstract class LogicAPI
    {
        public abstract class BallAPI
        {
            public abstract int GetID();
            public string color { get; set; }
            public static BallAPI CreateBall(int ID, int xPos, int yPos, int radius, int xMov, int yMov)
            {
                return new Ball(ID, xPos, yPos, radius, xMov, yMov);
            }

            public int XPos { get; set; }
            public int YPos { get; set; }
            public int XMove { get; set; }
            public int YMove { get; set; }

            public int Radius { get; set; }
            public int XPosition { get; set; }
            public int YPosition { get; set; }
        }

 

        public static LogicAPI CreateManager(int windowWidth, int windowHeight)
        {
            return new BallsManager(windowWidth, windowHeight);
        }
        public static BallAPI CreateBall(int ID, int xPos, int yPos, int radius, int xMov, int yMov)
        {
            return new Ball(ID,xPos, yPos, radius, xMov, yMov);
        }
        public abstract void SummonBalls(int amount);
        
        public abstract void DoTick();
        public abstract List<BallAPI> GetAllBalls();

        public abstract void ClearMap();
       

    }
}
