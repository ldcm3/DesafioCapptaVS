using System;
namespace SondaProject
{
    public interface IMovement 
    {
        SondaDevice ProcessCommands();
        void Move();
    }

    public class UpDownLeftRightMovement : IMovement
    {
        Coords2D initial_coords;
        Coords2D final_coords;
        SondaDevice _sonda;
        Instruction _instruction;
        Malha2D _malha2D;
        int invalid_executed_movements = 0;

        const int TURN_RIGHT = 1;
        const int TURN_LEFT = -1;

        public UpDownLeftRightMovement(SondaDevice sonda,IInstruction instruction,IMalha malha2D)
        {
            initial_coords = (Coords2D)sonda.GetCoords();
            final_coords = initial_coords; // in case of invalid instruction
            _sonda = sonda;
            _instruction = (Instruction)instruction;
            _malha2D = (Malha2D)malha2D;
        }

        public SondaDevice ProcessCommands()
        {
            char[] commands = _instruction.GetInstruction();

            foreach (char command in commands)
            {
                if (command == 'L')
                {
                    _sonda._direction.ChangeDirection(TURN_LEFT);
                }
                else if (command == 'R')
                {
                    _sonda._direction.ChangeDirection(TURN_RIGHT);
                }
                else // command ==  'M'
                {
                    try {
                        this.Move(); 
                    }
                    catch (NotAllowedMoveException) {
                        invalid_executed_movements += 1;
                    }
                   
                }
            }

            return _sonda;
        }

        public void Move()
        {
            char curDir = _sonda._direction.GetDirection();
            Coords2D nextCoord = final_coords;

            if (curDir == 'N')
            {
                nextCoord._y += 1;
            }
            else if (curDir == 'S')
            {
                nextCoord._y -= 1;
            }
            else if (curDir == 'E')
            {
                nextCoord._x += 1;
            }
            else
            {
                nextCoord._x -= 1;
            }

            if (_malha2D.IsValidPosition(nextCoord) && _malha2D.IsFreePosition(nextCoord))
            {
                _malha2D.RemoveSonda(final_coords);
                _sonda._position = nextCoord;
                _malha2D.AddSonda(_sonda);
                nextCoord = final_coords;
            }
           else
            {
                throw new NotAllowedMoveException();
            }
        }

    }
}

[Serializable]
public class NotAllowedMoveException : Exception
{
    public NotAllowedMoveException()
    {

    }

    public NotAllowedMoveException(string e)
        : base(String.Format("The movement is not allowed: {0}", e))
    {

    }

}