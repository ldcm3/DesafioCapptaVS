using System;
using System.Collections.Generic;

namespace SondaProject
{
    public interface IMalha
    {
        bool IsValidPosition(ICoordinates coord);
        bool IsFreePosition(ICoordinates coord);
        void AddSonda(SondaDevice sonda);
        void RemoveSonda(ICoordinates coord);
    }

    public class Malha2D : IMalha
	{
		private int _lenX;
		private int _lenY;
        private SondaDevice[,] planalto;

		public Malha2D(int coordMax_x, int coordMax_y)
		{
            _lenX = coordMax_x + 1;
            _lenY = coordMax_y + 1;

            planalto = new SondaDevice[_lenX, _lenY];
		}

        public bool IsValidPosition(ICoordinates coord)
		{
            Coords2D coords2D = (Coords2D)coord;
            return coords2D._x >= 0 && coords2D._y >= 0 &&
                           coords2D._x < _lenX && coords2D._y < _lenY;
		}

        public bool IsFreePosition(ICoordinates coord)
        {
            Coords2D coords2D = (Coords2D)coord;
            return planalto[coords2D._x, coords2D._y] == null;
        }

        public void AddSonda(SondaDevice sonda)
        {
            Coords2D coords2D = (Coords2D)sonda.GetCoords();

            if (!IsValidPosition(coords2D))
            {
                throw new InvalidPositionException(
                    "Coords are not valid or have been already taken.");
            }
            else if (!IsFreePosition(coords2D))
            {
                throw new NotFreePositionException();
            }

            planalto[coords2D._x, coords2D._y] = sonda;
        }

        public void RemoveSonda(ICoordinates coord)
		{
            Coords2D coords2D = (Coords2D)coord;

            if (!IsValidPosition(coords2D))
            {
                throw new InvalidPositionException(
                    "Coords are not valid");
            }

            planalto[coords2D._x, coords2D._y] = null;
		}
	}
}


[Serializable]
public class InvalidPositionException : Exception
{
    public InvalidPositionException()
    {

    }

    public InvalidPositionException(string e)
        : base(String.Format("Invalid Position: {0}", e))
    {

    }

}

[Serializable]
public class NotFreePositionException : Exception
{
    public NotFreePositionException()
    {

    }

    public NotFreePositionException(string e)
        : base(String.Format("The coordinate is not free: {0}", e))
    {

    }

}