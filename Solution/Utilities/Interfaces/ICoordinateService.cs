using Solution.Models;

namespace Solution.Utilities.Interfaces
{
    public interface ICoordinateService
    {
        public string CalculateRow(TriangleCoordinates input);

        public int CalculateColumn(TriangleCoordinates input);

        public TriangleId CalculateTriangleId(TriangleCoordinates input);

        public void ValidateCoordinates(TriangleCoordinates input, int coordinate);
    }
}
