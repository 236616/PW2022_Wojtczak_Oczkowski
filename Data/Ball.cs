namespace Data
{
    public class Ball
    {
        private readonly int _ballID;
        public int XPos { get; set; }
        public int YPos { get; set; }
        public int XMove { get; set; }
        public int YMove { get; set; }
        public int Radius { get; set; }
        public string color { get; }

        public Ball(int ID, int xPos, int yPos, int radius, int xMov, int yMov)
        {
            _ballID = ID;
            XPos = xPos;
            YPos = yPos;
            XMove = xMov;
            YMove = yMov;
            Radius = radius;
            color = Color.PickColor();
        }

        public int GetID()
        {
            return _ballID;
        }
    }
}