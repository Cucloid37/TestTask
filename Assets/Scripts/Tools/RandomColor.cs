using UnityEngine;
using Random = System.Random;

namespace TestTask
{
    public class RandomColor
    {
        private Color[] _colors;
        private Random _rnd;

        public RandomColor(Color[] colors)
        {
            _colors = colors;
            _rnd = new Random();
        }

        public Color GetRndColor()
        {
            var index = _rnd.Next(0, _colors.Length-1);
            return _colors[index];
        }
    }
}