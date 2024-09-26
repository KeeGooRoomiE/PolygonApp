using System.ComponentModel.DataAnnotations;

public partial class Polygon
{
    [Key]
    public int Id { get; set; }
    public List<Point> Points { get; set; } = new List<Point>();
}

public class Point
{
    public double X { get; set; }
    public double Y { get; set; }
}