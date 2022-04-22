
namespace LogicLayer
{
    internal class Ball:LogicAPI.BallAPI
    {
        private readonly int _ballID;
        public string color { get; }

        public Ball(int ID, int xPos, int yPos, int radius, int xMov, int yMov)
        {
            _ballID = ID;
            XPos = xPos;
            YPos = yPos;
            XMove = xMov;
            YMove = yMov;
            Radius = radius;
            color = Color.ChooseColor();
        }

        override public int GetID()
        {
            return _ballID;
        }
    }
}