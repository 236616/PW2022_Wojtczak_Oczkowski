using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    internal class Color
    {
        public static string ChooseColor()
        {
            string[] _color = { "#CC0033", "#FF9933", "#E9C2A6", "#4D4DFF", "#4F2F4F", "#E57373", "#CE93D8", "#FFC107", "#9575CD", "#660033" };
            Random rnd = new Random();
            return _color[rnd.Next(10)];
        }
    }

}
