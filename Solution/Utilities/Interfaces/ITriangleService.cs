using Solution.Models;

namespace Solution.Utilities.Interfaces
{
    public interface ITriangleService
    {
        public int CalculateStep(TriangleId input);
        public TriangleCoordinates CalculateCoordinates(TriangleId input);
        public void ValidateId(TriangleId input);
    }
}
