using System;
using Xunit;
using SondaProject;

namespace SondaTests
{

    public class Malha2DTest
    {
        // Coordenada do ponto superior-direito da malha do planalto
        // Sendo que a inferior esquerda sempre será (0,0).
        const int COORD_X_LIMIT= 5;
        const int COORD_Y_LIMIT = 5;
  
        public static Coords2D bad_coords_to_test = new Coords2D  (10, 2);
        public static Coords2D good_coords_to_test = new Coords2D(1, 2);

        public static FourDirection direction_to_test = new FourDirection('N');
        public static Coords2D coords2D_to_test = new Coords2D(3, 4);


        public class IsValidPositionMethod
        {
            [Fact]
            public void ValidPositionReturnsTrue()
            {
                Malha2D marte = new Malha2D(COORD_X_LIMIT, COORD_Y_LIMIT);
                Assert.True(marte.IsValidPosition(good_coords_to_test));
            }

            [Fact]
            public void InvalidCoordsReturnsFalse()
            {
                Malha2D marte = new Malha2D(COORD_X_LIMIT, COORD_Y_LIMIT);
                Assert.False(marte.IsValidPosition(bad_coords_to_test));

            }

        }

        public class IsFreePositionMethod
        {
            [Fact]
            public void PositionIsTakenByAnotherSondaReturnsFalse()
            {
                Malha2D marte = new Malha2D(COORD_X_LIMIT, COORD_Y_LIMIT);
                SondaDevice sonda = new SondaDevice(direction_to_test, coords2D_to_test);
                marte.AddSonda(sonda);
                Assert.False(marte.IsFreePosition(coords2D_to_test));

            }
        }

        public class AddSondaMethod
        {
            [Fact]
            public void PositionIsTakenByAnotherSondaThrowsException()
            {
                Malha2D marte = new Malha2D(COORD_X_LIMIT, COORD_Y_LIMIT);
                SondaDevice sonda = new SondaDevice(direction_to_test, coords2D_to_test);
                marte.AddSonda(sonda);
                Assert.Throws<NotFreePositionException>(() =>
                                                        marte.AddSonda(sonda));

            }
        }

        public class RemoveSondaMethod
        {
            [Fact]
            public void PositionIsTakenByAnotherSondaThrowsException()
            {
                Malha2D marte = new Malha2D(COORD_X_LIMIT, COORD_Y_LIMIT);
                SondaDevice sonda = new SondaDevice(direction_to_test, coords2D_to_test);
                marte.AddSonda(sonda);
                Assert.Throws<NotFreePositionException>(() =>
                                                        marte.AddSonda(sonda));

            }
        }
    }
}
        