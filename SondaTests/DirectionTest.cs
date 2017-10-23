using System;
using Xunit;
using SondaProject;

namespace SondaTests
{
    public class FourDirectionTest
    {

        const int TURN_RIGHT = 1;
        const int TURN_LEFT = -1;
        const char INVALID_DIR = 'I';

        public class TheGetDirectionMethod
        {
            [Fact]
            public void ValidDirection()
            {
                FourDirection dir = new FourDirection('N');
                Assert.Equal('N', dir.GetDirection());
            }

            [Fact]
            public void Invalid_Direction_Throws_ArgumentException()
            {
                FourDirection dir;
                Assert.Throws<ArgumentException>(() =>
                                                 dir = new FourDirection(INVALID_DIR));
            }

        }

        public class TheChangeDirectionMethod
        {
            [Fact]
            public void Change360DegreesToTheRight()
            {
                FourDirection dir = new FourDirection('N');
                for (int i = 0; i < 4; ++i)
                {
                    dir.ChangeDirection(TURN_RIGHT);
                }

                Assert.Equal('N', dir.GetDirection());
            }

            [Fact]
            public void Change360DegreesToTheLeft()
            {
                FourDirection dir = new FourDirection('S');

                for (int i = 0; i < 4; ++i)
                {
                    dir.ChangeDirection(TURN_LEFT);
                }
                Assert.Equal('S', dir.GetDirection());
            }

            [Fact]
            public void ChangeFromReferenceToLeft()
            {
                FourDirection dir = new FourDirection('N');
                dir.ChangeDirection(TURN_LEFT);
                Assert.Equal('W', dir.GetDirection());
            }

        }

    }
}
