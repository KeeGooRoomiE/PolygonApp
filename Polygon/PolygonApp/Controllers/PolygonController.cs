using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PolygonController : ControllerBase
{
    private readonly PolygonService _polygonService;

    public PolygonController(PolygonService polygonService)
    {
        _polygonService = polygonService;
    }

    [HttpPost("save")]
    public IActionResult SavePolygon([FromBody] Polygon polygon)
    {
        _polygonService.SavePolygon(polygon);
        return CreatedAtAction(nameof(GetPolygonById), new { id = polygon.Id }, polygon);
    }

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

    [HttpGet("{id}")]
    public IActionResult GetPolygonById(int id)
    {
        var polygon = _polygonService.GetPolygonById(id);
        if (polygon == null)
        {
            return NotFound();
        }

        return Ok(polygon);
    }
}