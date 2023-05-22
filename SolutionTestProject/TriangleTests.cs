using Solution.Models;
using Solution.Utilities.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionTestProject
{
    public class TriangleTests
    {
        public const int ASCII_A = 97;

        [Fact]
        public void CalculateStep_Returns_Correct_Value()
        {
            //Arrange 
            var triangleService = new TriangleService();

            var triangle = new TriangleId
            {
                Row = "a",
                Column = 1
            };

            //Act 
            var stepValid = triangleService.CalculateStep(triangle);

            //Assert
            Assert.Equal(0, stepValid);
        }

        [Fact]
        public void CalculateStep_Throws_Exception_On_Invalid_Row_Name()
        {
            //Arrange 
            var triangleService = new TriangleService();

            var invalidTriangle = new TriangleId
            {
                Row = ".",
                Column = 1
            };

            //Act 

            //Assert
            Assert.Throws<ArgumentException>(() => triangleService.CalculateStep(invalidTriangle));
        }

        [Fact]
        public void CalculateStep_Throws_Exception_On_Invalid_Column_Name()
        {
            //Arrange 
            var triangleService = new TriangleService();

            var invalidTriangle = new TriangleId
            {
                Row = "a",
                Column = 0
            };

            //Act 

            //Assert
            Assert.Throws<ArgumentException>(() => triangleService.CalculateStep(invalidTriangle));
        }

        [Fact]
        public void CalculateCoordinates_Returns_Correct_Value_If_Col_Odd()
        {
            //Arrange 
            var triangleService = new TriangleService();

            var validTriangle = new TriangleId
            {
                Row = "a",
                Column = 1
            };

            //Act
            var triangle = triangleService.CalculateCoordinates(validTriangle);

            //Assert
            Assert.Equal(10, triangle.A.y);
            Assert.Equal(0, triangle.A.x);
            Assert.Equal(10, triangle.B.y);
            Assert.Equal(10, triangle.B.x);
            Assert.Equal(0, triangle.C.y);
            Assert.Equal(0, triangle.C.x);
        }

        [Fact]
        public void CalculateCoordinates_Returns_Correct_Value_If_Col_Even()
        {
            //Arrange 
            var triangleService = new TriangleService();

            var validTriangle = new TriangleId
            {
                Row = "a",
                Column = 2
            };

            //Act
            var triangle = triangleService.CalculateCoordinates(validTriangle);

            //Assert
            Assert.Equal(0, triangle.A.y);
            Assert.Equal(10, triangle.A.x);
            Assert.Equal(10, triangle.B.y);
            Assert.Equal(10, triangle.B.x);
            Assert.Equal(0, triangle.C.y);
            Assert.Equal(0, triangle.C.x);
        }

        [Fact]
        public void ValidateId_Does_Not_Throw_If_Input_Valid()
        {
            //Arrange 
            var triangleService = new TriangleService();

            var validTriangle = new TriangleId
            {
                Row = "a",
                Column = 1
            };

            //Act
            var exception = Record.Exception(() => triangleService.ValidateId(validTriangle));

            //Assert
            Assert.Null(exception);
        }

        [Fact]
        public void ValidateId_Throws_Exception_If_Row_Does_Not_Match_Regex()
        {
            //Arrange 
            var triangleService = new TriangleService();

            var invalidTriangle = new TriangleId
            {
                Row = ".",
                Column = 1
            };

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() => triangleService.ValidateId(invalidTriangle));
        }

        [Fact]
        public void ValidateId_Throws_Exception_If_Row_Matches_Regex_But_Is_More_Than_One_Character()
        {
            //Arrange 
            var triangleService = new TriangleService();

            var invalidTriangle = new TriangleId
            {
                Row = "aa",
                Column = 1
            };

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() => triangleService.ValidateId(invalidTriangle));
        }

        [Fact]
        public void ValidateId_Throws_Exception_If_Column_Nr_Less_Than_One()
        {
            //Arrange 
            var triangleService = new TriangleService();

            var invalidTriangle = new TriangleId
            {
                Row = "a",
                Column = 0
            };

            //Act

            //Assert
            Assert.Throws<ArgumentException>(() => triangleService.ValidateId(invalidTriangle));
        }
    }
}