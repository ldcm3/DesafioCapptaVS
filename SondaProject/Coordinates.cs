using System;
namespace SondaProject
{
    public abstract class ICoordinates
    {
    }

    public class Coords2D : ICoordinates
    {
        public int _x { get; set; }
        public int _y { get; set; }

        public Coords2D(int x, int y)
        {
            _x = x;
            _y = y;
        }
    }
}
