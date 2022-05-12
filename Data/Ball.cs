
using Data;
using System.ComponentModel;

namespace LogicLayer
{
    internal class Ball : DataAPI, INotifyPropertyChanged
    {
        private readonly int _ballID;


        internal Ball(int xPosition, int yPosition)
        {
            XPosition = xPosition;
            YPosition = yPosition;

            Radius = 20;
            mass = 15;
            Random rnd = new Random();
            do
            {
                vx = rnd.Next(-3, 3);
                vy = rnd.Next(-3, 3);
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
    }
}