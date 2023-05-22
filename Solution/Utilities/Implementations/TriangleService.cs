using Solution.Models;
using Solution.Utilities.Interfaces;
using System.Text;
using System.Text.RegularExpressions;

namespace Solution.Utilities.Implementations
{
    public class TriangleService : ITriangleService
    {
        public const int ASCII_A = 97;

        public int CalculateStep(TriangleId input)
        {
            int step;

            ValidateId(input);

            byte[] asciiBytes = Encoding.ASCII.GetBytes(input.Row);

            step = asciiBytes[0] - ASCII_A;


            return step;
        }

        public TriangleCoordinates CalculateCoordinates(TriangleId input)
        {
            int step = CalculateStep(input);
            int col = input.Column;

            var output = new TriangleCoordinates()
            {
                A = new Coordinate() { y = 0, x = 0 },
                B = new Coordinate() { y = 0, x = 0 },
                C = new Coordinate() { y = 0, x = 0 },
            };

            if (col % 2 == 0)
            {
                output.A.y = step * 10;
                output.A.x = col / 2 * 10;
                output.B.y = (step + 1) * 10;
                output.B.x = col / 2 * 10;
                output.C.y = step * 10;
                output.C.x = (col - 2) / 2 * 10;
            }

            if (col % 2 != 0)
            {
                output.A.x = (col + 1) / 2 * 10 - 10;
                output.A.y = step * 10 + 10;
                output.B.x = (col + 1) / 2 * 10;
                output.B.y = (step + 1) * 10;
                output.C.x = (col - 1) / 2 * 10;
                output.C.y = step * 10;
            }

            return output;
        }

        public void ValidateId(TriangleId input)
        {
            Regex regex = new Regex("^[a-z]$");

            if (regex.Matches(input.Row).Count() == 0)
            {
                throw new ArgumentException("Input can only contain one character between a-z.");
            }

            if (input.Column < 1)
            {
                throw new ArgumentException("Input row has to a be a positive number.");
            }
        }
    }
}
