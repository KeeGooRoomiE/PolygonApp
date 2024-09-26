public class CheckPointRequest
{
    public int PolygonId { get; set; } 
    public Point Point { get; set; } 

    public CheckPointRequest(int polygonId, Point point)
    {
        PolygonId = polygonId;
        Point = point;
    }
}