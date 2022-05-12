using LogicLayer;
using System.ComponentModel;

namespace Data
{
    public abstract class DataAPI
    {
        public static DataAPI getBall(int x, int y)
        {
            return new Ball(x, y);
        }

        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public int Radius { get; set; }

        public int vx { get; set; }
        public int vy { get; set; }

        public double mass { get; set; }

        public abstract void move();

        public abstract event PropertyChangedEventHandler? PropertyChanged;
    }

    public abstract class Box
    {
        public static int width { get; set; }
        public static int height { get; set; }

    }
}
