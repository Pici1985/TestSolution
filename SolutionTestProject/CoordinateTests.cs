using Solution.Models;
using Solution.Utilities.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionTestProject
{
    public class CoordinateTests
    {
        public const int ASCII_A = 97;

        [Fact]
        public void CalculateRow_Returns_Correct_Row()
        {
            //Arrange 
            var coordinateService = new CoordinateService();

            var coordinates = new TriangleCoordinates
            {
                A = new Coordinate { x = 0, y = 10 },
                B = new Coordinate { x = 10, y = 10 },
                C = new Coordinate { x = 0, y = 0 }
            };

            //Act 
            var rowValid = coordinateService.CalculateRow(coordinates);

            //Assert
            Assert.Equal("a", rowValid);
        }

        [Fact]
        public void CalculateColumn_Returns_Correct_Value_If_Col_Odd()
        {
            //Arrange 
            var coordinateService = new CoordinateService();

            var coordinates = new TriangleCoordinates
            {
                A = new Coordinate { x = 0, y = 10 },
                B = new Coordinate { x = 10, y = 10 },
                C = new Coordinate { x = 0, y = 0 }
            };

            //Act 
            var colValidOdd = coordinateService.CalculateColumn(coordinates);

            //Assert
            Assert.Equal(1, colValidOdd);
        }

        [Fact]
        public void CalculateColumn_Returns_Correct_Value_If_Col_Even()
        {
            //Arrange 
            var coordinateService = new CoordinateService();

            var coordinates = new TriangleCoordinates
            {
                A = new Coordinate { x = 10, y = 0 },
                B = new Coordinate { x = 10, y = 10 },
                C = new Coordinate { x = 0, y = 0 }
            };

            //Act 
            var colValidEven = coordinateService.CalculateColumn(coordinates);

            //Assert
            Assert.Equal(2, colValidEven);
        }

        [Fact]
        public void ValidateCoordinates_Does_Not_Throw_If_Input_Valid()
        {
            //Arrange 
            var coordinateService = new CoordinateService();

            var triangle = new TriangleCoordinates
            {
                A = new Coordinate { x = 0, y = 10 },
                B = new Coordinate { x = 10, y = 10 },
                C = new Coordinate { x = 0, y = 0 }
            };

            var coordinate = triangle.C.y / 10;

            //Act
            var exception = Record.Exception(() => coordinateService.ValidateCoordinates(triangle, coordinate));

            //Assert
            Assert.Null(exception);
        }

        [Fact]
        public void ValidateCoordinates_Throws_If_Triangle_Invalid()
        {
            //Arrange 
            var coordinateService = new CoordinateService();

            var invalidTriangle = new TriangleCoordinates
            {
                A = new Coordinate { x = 10, y = 10 },
                B = new Coordinate { x = 10, y = 10 },
                C = new Coordinate { x = 0, y = 0 }
            };

            var coordinate = invalidTriangle.C.y / 10;

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() => coordinateService.ValidateCoordinates(invalidTriangle, coordinate));
        }

        [Fact]
        public void ValidateCoordinates_Throws_If_InputCy_Invalid()
        {
            //Arrange 
            var coordinateService = new CoordinateService();

            var invalidTriangle = new TriangleCoordinates
            {
                A = new Coordinate { x = 0, y = 10 },
                B = new Coordinate { x = 10, y = 10 },
                C = new Coordinate { x = 0, y = 25 }
            };

            var coordinate = invalidTriangle.C.y / 10;

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() => coordinateService.ValidateCoordinates(invalidTriangle, coordinate));
        }

        [Fact]
        public void ValidateCoordinates_Throws_If_Coordinate_Invalid()
        {
            //Arrange 
            var coordinateService = new CoordinateService();

            var validTriangle = new TriangleCoordinates
            {
                A = new Coordinate { x = 0, y = 10 },
                B = new Coordinate { x = 10, y = 10 },
                C = new Coordinate { x = 0, y = 0 }
            };

            // coordinate = 0 < invalidTriangle.C.y / 10 < 26; 
            var coordinate = 26;

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() => coordinateService.ValidateCoordinates(validTriangle, coordinate));
        }

        [Fact]
        public void CalculateTriangleId_Returns_TrinagleId_If_Input_Valid()
        {
            //Arrange 
            var coordinateService = new CoordinateService();

            var triangle = new TriangleCoordinates
            {
                A = new Coordinate { x = 0, y = 10 },
                B = new Coordinate { x = 10, y = 10 },
                C = new Coordinate { x = 0, y = 0 }
            };

            //Act
            var TrinagleId = coordinateService.CalculateTriangleId(triangle);

            //Assert
            Assert.Equal("a", TrinagleId.Row);
            Assert.Equal(1, TrinagleId.Column);
        }
    }
}
