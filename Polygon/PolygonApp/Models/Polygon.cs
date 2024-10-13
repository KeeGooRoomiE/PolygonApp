namespace PolygonApp.Models
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    public class Polygon
    {
        public int Id { get; set; }
        public List<Point> Points { get; set; } = new List<Point>();
    }

    public class CheckPointRequest
    {
        public int PolygonId { get; set; }
        public Point Point { get; set; }
    }
}