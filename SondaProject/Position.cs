using System;
using System.Collections.Generic;

namespace SondaProject
{

    public interface IPosition
    {
        int [] GetCoords();
    }

    public class Cartesian2D : IPosition
    {
        private int _coordX;
        private int _coordY;

        public Cartesian2D(int coordX, int coordY)
        {
            _coordX = coordX;
            _coordY = coordY;
        }

        public int [] GetCoords()
        {
            return new int[] {_coordX, _coordY};
        }
    }

    public class Cartesian3D : IPosition
    {
        private int _coordX;
        private int _coordY;
        private int _coordZ;

        public Cartesian3D(int coordX, int coordY, int coordZ)
        {
            _coordX = coordX;
            _coordY = coordY;
            _coordZ = coordZ;
        }

        public int [] GetCoords()
        {
            return new int[] {_coordX, _coordY, _coordZ};
        }
    }
}
