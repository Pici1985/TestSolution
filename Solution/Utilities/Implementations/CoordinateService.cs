using Solution.Models;
using Solution.Utilities.Interfaces;

namespace Solution.Utilities.Implementations
{
    public class CoordinateService : ICoordinateService
    {
        public const int ASCII_A = 97;
        public string CalculateRow(TriangleCoordinates input)
        {
            var coordinate = input.C.y / 10;

            ValidateCoordinates(input, coordinate);

            int asciiCode = coordinate + ASCII_A;

            string row = Convert.ToChar(asciiCode).ToString();

            return row;
        }

        public int CalculateColumn(TriangleCoordinates input)
        {
            int col = 0;

            if (input.A.y == input.B.y && input.A.x == input.C.x)
            {
                col = input.C.x / 10 * 2 + 1;
            }

            if (input.A.y == input.C.y && input.A.x == input.B.x)
            {
                col = input.A.x / 10 * 2;
            }

            return col;
        }

        public void ValidateCoordinates(TriangleCoordinates input, int coordinate)
        {
            var B_A = input.B.y + input.B.x - (input.A.y + input.A.x);
            var B_C = input.B.y + input.B.x - (input.C.y + input.C.x);
            var A_C = input.A.y + input.A.x - (input.C.y + input.C.x);

            if (B_A != 10 || B_C != 20 || A_C != 10)
            {
                throw new ArgumentException("Invalid Triangle.");
            }

            if (input.C.y % 10 != 0)
            {
                throw new ArgumentException("Invalid Coordinates.");
            }

            if (coordinate < 0 || coordinate > 25)
            {
                throw new ArgumentException("Coordinate out of range.");
            }
        }

        public TriangleId CalculateTriangleId(TriangleCoordinates input)
        {
            var triangle = new TriangleId()
            {
                Row = CalculateRow(input),
                Column = CalculateColumn(input)
            };

            return triangle;
        }
    }
}
