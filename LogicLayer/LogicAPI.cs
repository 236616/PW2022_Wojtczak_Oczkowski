using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public abstract class LogicAPI
    {

        public static LogicAPI CreateBox(int width, int height)
        {
            Box.width = width;
            Box.height = height;
            return new BallsManager();
        }

        public abstract void SummonBalls(int amount);

        public abstract void createBalls(int amount);

        public abstract void DoTick();
        public abstract List<SBallAPI> GetAllBalls();

        public abstract void ClearMap();

        public object _lock = new object();

        public bool isMoving { get; set; }

        public List<Thread> threads;
        public List<Thread> loggers;
        public abstract bool EdgeBounce(DataAPI ball);

        public abstract List<DataAPI> GetOldBalls();

    }
    public abstract class SBallAPI
    {
        public static SBallAPI Create(int x, int y)
        {
            return new SBall(x, y);
        }
        virtual public int XPos { get; set; }
        public int YPos { get; set; }
        public int Radius { get; set; }
    }

}
