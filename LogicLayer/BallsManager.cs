using Data;

namespace LogicLayer
{
    internal class BallsManager : LogicAPI
    {
        internal readonly int _Radius = 15;
        internal readonly List<DataAPI> _ballStorage = new();
        internal readonly List<Logger> _loggerStorage = new();
        public void assignThreads()
        {
            threads = new List<Thread>();

            foreach (DataAPI ball in _ballStorage)
            {
                Thread t = new Thread(() =>
                {
                    bool flagEdge = false;
                    bool flagCollision = false;
                    while (isMoving)
                    {
                        ball.move();
                        flagEdge = EdgeBounce(ball);
                        lock (_lock)
                        {
                            flagCollision = Collisions(ball);
                        }
                        if (flagEdge || flagCollision)
                        {
                            _loggerStorage[ball.id].log();
                            flagEdge = false;
                            flagCollision = false;
                        }
                        Thread.Sleep(5);
                    }
                });
                threads.Add(t);
            }
        }

        public override void SummonBalls(int amount)
        {
            createBalls(amount);
            assignThreads();

            if (!isMoving)
            {
                isMoving = true;
                foreach (Thread t in threads)
                {
                    t.Start();
                }
            }
        }

        override public void createBalls(int amount)
        {
            Random rnd = new Random();
            for (int i = 0; i < amount; i++)
            {
                int xPos = rnd.Next(_Radius, Box.width - _Radius);
                int yPos = rnd.Next(_Radius, Box.height - _Radius);
                DataAPI ball = DataAPI.getBall(xPos, yPos, i);
                _ballStorage.Add(ball);
                _loggerStorage.Add(new Logger(ball));
            }
        }

        public override bool EdgeBounce(DataAPI ball)
        {
            bool flag = false;
            if (ball.XPosition <= ball.Radius)            // hit left edge, go right
            {
                ball.vx = Math.Abs(ball.vx);
                flag = true;
            }
            if (ball.XPosition >= Box.width - ball.Radius)    // hit right edge, go left
            {
                ball.vx = Math.Abs(ball.vx) * (-1);
                flag = true;
            }

            if (ball.YPosition <= ball.Radius)            // hit bottom edge, go up
            {
                ball.vy = Math.Abs(ball.vy);
                flag = true;
            }
            if (ball.YPosition >= Box.height - ball.Radius)   // hit top edge, go down
            {
                ball.vy = Math.Abs(ball.vy) * (-1);
                flag = true;
            }
            return flag;
        }

        private bool Collisions(DataAPI ball)
        {
            DataAPI? collided = FindCollisions(ball);
            if (collided != null)
            {
                double newX1, newX2, newY1, newY2;

                newX1 = (ball.vx * (ball.mass - collided.mass) / (ball.mass + collided.mass) + (2 * collided.mass * collided.vx) / (ball.mass + collided.mass));
                newY1 = (ball.vy * (ball.mass - collided.mass) / (ball.mass + collided.mass) + (2 * collided.mass * collided.vy) / (ball.mass + collided.mass));

                newX2 = (collided.vx * (collided.mass - ball.mass) / (ball.mass + collided.mass) + (2 * ball.mass * ball.vx) / (ball.mass + collided.mass));
                newY2 = (collided.vy * (collided.mass - ball.mass) / (ball.mass + collided.mass) + (2 * ball.mass * ball.vy) / (ball.mass + collided.mass));

                ball.vx = (int)newX1;
                ball.vy = (int)newY1;
                collided.vx = (int)newX2;
                collided.vy = (int)newY2;
                return true;
            }
            return false;
        }

        private DataAPI? FindCollisions(DataAPI ball)
        {
            foreach (DataAPI other in _ballStorage)
            {
                if (other == ball)
                    continue;
                double distance = Math.Sqrt(Math.Pow((ball.XPosition + ball.vx - other.XPosition + other.vx), 2) +
                                            Math.Pow((ball.YPosition + ball.vy - other.YPosition + other.vy), 2));
                if (distance <= ball.Radius + other.Radius)
                    return other;
            }
            return null;
        }

        public override void ClearMap()
        {
            isMoving = false;
            threads.Clear();
            _ballStorage.Clear();
        }

        override public List<SBallAPI> GetAllBalls()
        {
            List<SBallAPI> list = new();
            foreach (DataAPI ball in _ballStorage)
            {
                list.Add(new SBall(ball.XPosition, ball.YPosition));
            }
            return list;
        }

        override public List<DataAPI> GetOldBalls()
        {
            List<DataAPI> list = new();
            foreach (DataAPI ball in _ballStorage)
            {
                list.Add(ball);
            }
            return list;
        }

        public override void DoTick()
        {
            throw new NotImplementedException();
        }

    }
}