using System;
using System.Collections.Generic;

namespace SondaProject
{

    public interface IDirection
    {
        char GetDirection();
        void ChangeDirection(int rotate);
    }

    public class FourDirection : IDirection
    {

        const int NORTH = 0, EAST = 1, SOUTH = 2, WEST = 3, N_OF_DIRS = 4;

        private int curDir;
        private char[] mapDirection = { 'N', 'E', 'S', 'W' };
        private List<char> validDirs = new List<char>()
        {
            'N', 'E', 'S', 'W'
        };
         
            
        public FourDirection(char dir)
        {
            if (!IsValidDirection(dir))
            {
                throw new ArgumentException(String.Format
                                            ("{0} is not a valid direction", dir));
            }
                
            switch (dir)
            {
                case 'N':
                    curDir = NORTH;
                    break;
                case 'E':
                    curDir = EAST;
                    break;
                case 'S':
                    curDir = SOUTH;
                    break;
                case 'W':
                    curDir = WEST;
                    break;
            }
        }

        bool IsValidDirection(char dir)
        {
            return validDirs.Contains(dir);
        }

        public char GetDirection()
        {
            return mapDirection[curDir];
        }

        public void ChangeDirection(int rotate)
        {
            int nextDir = (curDir + rotate) % N_OF_DIRS;
            // Circle directions. Reference is NORTH
            curDir = nextDir < 0 ? WEST : nextDir;
		}
    }

}
