using System;
using System.Collections.Generic;

namespace SondaProject
{
    public class SondaDevice
    {
        public IDirection _direction;
        public ICoordinates _position;

        // Construtor
        public SondaDevice(IDirection direction, ICoordinates position)
        {
            _direction = direction;
            _position = position;
        }

        public ICoordinates GetCoords()
        {
            return _position;
        }
    }
}
