
using Data;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace LogicLayer
{
    internal class Ball : DataAPI, INotifyPropertyChanged
    {
        private readonly int _ballID;


        internal Ball(int xPosition, int yPosition, int ID)
        {
            XPosition = xPosition;
            YPosition = yPosition;
            id = ID;
            Radius = 20;
            mass = 15;
            Random rnd = new Random();
            do
            {
                vx = rnd.Next(-2, 2);
                vy = rnd.Next(-2, 2);
            } while (vx == 0 || vy == 0);

        }



        public override event PropertyChangedEventHandler? PropertyChanged;

        public int GetID()
        {
            return _ballID;
        }

        public override void move()
        {
            XPosition += vx;
            YPosition += vy;
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(XPosition), XPosition);
        }

    }


}