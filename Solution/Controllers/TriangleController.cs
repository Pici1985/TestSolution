using Solution.Utilities.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solution.Models;
using Solution.Utilities.Interfaces;

namespace Solution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TriangleController : ControllerBase
    {
        private readonly ITriangleService _triangleService;
        private readonly ICoordinateService _coordinateService;
        public TriangleController(ITriangleService triangleService, ICoordinateService coordinateService)
        {
            _triangleService = triangleService;
            _coordinateService = coordinateService;
        }

        [Route("/triangleid")]
        [HttpPost]
        public IActionResult CalculateCoordinates([FromBody] TriangleId input)
        {
            try
            {
                var coordinates = _triangleService.CalculateCoordinates(input);
                return Ok(coordinates);
            }
            catch (ArgumentException ex)
            {
                return BadRequest("Invalid parameters");
            }
        }

        [Route("/coordinates")]
        [HttpPost]
        public IActionResult CalculateTringleId([FromBody] TriangleCoordinates input)
        {
            try
            {
                var triangle = _coordinateService.CalculateTriangleId(input);
                return Ok(triangle);
            }
            catch (ArgumentException ex)
            {
                return BadRequest("Invalid parameters");
            }
        }
    }
}
