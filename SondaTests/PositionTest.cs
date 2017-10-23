using System;
using Xunit;
using SondaProject;

namespace SondaTests
{
    public class Cartesian2DTest
    {

        public class TheGetCoordsMethod
        {
            [Fact]
            public void GetArrOfCoords()
            {
                int[] setCoords = { 3, 4 };
                Cartesian2D cartesian2D = new Cartesian2D(setCoords[0],setCoords[1]);
                int[] coordsToTest = cartesian2D.GetCoords();

                for (int i = 0; i < coordsToTest.Length; ++i)
                {
                    Assert.Equal(setCoords[i], coordsToTest[i]);
                }
            }
        }
    }


    public class Cartesian3DTest
    {
        public class TheGetCoordsMethod
        {
            [Fact]
            public void GetArrOfCoords()
            {
                int[] setCoords = { 3, 4, 5 };

                Cartesian3D cartesian3D = new Cartesian3D(
                                            setCoords[0], setCoords[1], setCoords[2]);
                int[] coordsToTest = cartesian3D.GetCoords();

                for (int i = 0; i < coordsToTest.Length; ++i)
                {
                    Assert.Equal(setCoords[i], coordsToTest[i]);
                }
            }
        }

    }
}