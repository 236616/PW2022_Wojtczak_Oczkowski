using LogicLayer;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Data
{
    public abstract class DataAPI : ISerializable
    {
        public static DataAPI getBall(int x, int y, int id)
        {
            return new Ball(x, y, id);
        }
        public int id { get; set; }
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public int Radius { get; set; }

        public int vx { get; set; }
        public int vy { get; set; }

        public double mass { get; set; }

        public abstract void move();

        public abstract void GetObjectData(SerializationInfo info, StreamingContext context);

        public abstract event PropertyChangedEventHandler? PropertyChanged;
    }

    public abstract class Box
    {
        public static int width { get; set; }
        public static int height { get; set; }

    }
}
