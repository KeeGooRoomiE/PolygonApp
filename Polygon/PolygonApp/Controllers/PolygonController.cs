using Microsoft.AspNetCore.Mvc;
using PolygonApp.Models;
using PolygonApp.Services;

namespace PolygonApp.Controllers
{
    [ApiController]
    [Route("api/polygons")]
    public class PolygonController : ControllerBase
    {
        private readonly PolygonService _polygonService;

        public PolygonController(PolygonService polygonService)
        {
            _polygonService = polygonService;
        }

        // Создание полигона
        [HttpPost]
        public IActionResult CreatePolygon([FromBody] List<Point> points)
        {
            var polygon = _polygonService.CreatePolygon(points);
            return Ok(polygon);
        }

        // Проверка точки в полигоне
        [HttpPost("check-point")]
        public IActionResult CheckPoint([FromBody] CheckPointRequest request)
        {
            var polygon = _polygonService.GetPolygonById(request.PolygonId);
            if (polygon == null)
            {
                return NotFound();
            }

            bool isInside = _polygonService.IsPointInPolygon(request.Point, polygon);
            return Ok(new { IsInside = isInside });
        }
        
        [HttpPost("increment-counter")]
        public IActionResult IncrementCounter()
        {
            var newCount = _polygonService.IncrementCounter();
            return Ok(new { Counter = newCount });
        }
    }
}