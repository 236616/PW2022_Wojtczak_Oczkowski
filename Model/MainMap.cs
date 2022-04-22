using Data;
using LogicLayer;

namespace Presentation.Model
{
    public class MainMap
    {
        private readonly LogicAPI _ballsManager;
        private int _width;
        private int _height;

        public void Tick()
        {
            _ballsManager.DoTick();
        }

        public MainMap(int w, int h)
        {
            _width = w;
            _height = h;
            _ballsManager = LogicAPI.CreateManager(_width, _height);
        }

       public List<LogicAPI.BallAPI> GetBalls()
        {
            return _ballsManager.GetAllBalls();
        }

        public void CreateBalls(int amount)
        {
            _ballsManager.SummonBalls(amount);
        }

        public void ClearMap()
        {
            _ballsManager.ClearMap();
        }
    }
}