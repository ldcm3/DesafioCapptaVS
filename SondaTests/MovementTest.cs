using System;
using Xunit;
using SondaProject;

namespace SondaTests
{
    
    public class MovementTest
    {

        public class ProcessCommandsMethod
        {
            [Fact]
            public void ValidateGoodMovementTest1()
            {
                IMalha malha = new Malha2D(5, 5);
                ICoordinates coords = new Coords2D(3, 3);
                IDirection dir = new FourDirection('E');

                SondaDevice sonda = new SondaDevice(dir, coords);
                IInstruction instruc = new Instruction("MMRMMRMRRM");

                IMovement movement = new UpDownLeftRightMovement(sonda, instruc, malha);
                SondaDevice sondaAfterCommands = movement.ProcessCommands();
                Coords2D final_coords = (Coords2D)sondaAfterCommands.GetCoords();

                Coords2D expected_coords = new Coords2D(5, 1);
                FourDirection expected_direction = new FourDirection('E');

                Assert.Equal(expected_coords._x, final_coords._x);
                Assert.Equal(expected_coords._y, final_coords._y);
                Assert.Equal(sondaAfterCommands._direction.GetDirection(), expected_direction.GetDirection());
            }

            [Fact]
            public void ValidateGoodMovementTest2()
            {
                IMalha malha = new Malha2D(5,5);
                ICoordinates coords = new Coords2D(1, 2);
                IDirection dir = new FourDirection('N');

                SondaDevice sonda = new SondaDevice(dir, coords);
                IInstruction instruc = new Instruction("LMLMLMLMM");

                IMovement movement = new UpDownLeftRightMovement(sonda, instruc, malha);
                SondaDevice sondaAfterCommands = movement.ProcessCommands();
                Coords2D final_coords = (Coords2D)sondaAfterCommands.GetCoords();

                Coords2D expected_coords = new Coords2D(1, 3);
                FourDirection expected_direction = new FourDirection('N');

                Assert.Equal(expected_coords._x, final_coords._x);
                Assert.Equal(expected_coords._y, final_coords._y);
                Assert.Equal(sondaAfterCommands._direction.GetDirection(),expected_direction.GetDirection());

            }

            //[Fact]
            //public void ValidateBadMovement()
            //{

            //}

        }
    }
}