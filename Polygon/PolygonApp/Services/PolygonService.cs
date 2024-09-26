public class PolygonService
{
    private readonly PolygonContext _context;

    public PolygonService(PolygonContext context)
    {
        _context = context;
    }

    public void SavePolygon(Polygon polygon)
    {
        _context.Polygons.Add(polygon);
        _context.SaveChanges();
    }

    public bool IsPointInPolygon(Point point, Polygon polygon)
    {
        bool inside = false; 
        int count = polygon.Points.Count;

        for (int i = 0; i < count; i++)
        {
            int j = (i + 1) % count; 

    
            bool condition1 = (polygon.Points[i].Y > point.Y) != (polygon.Points[j].Y > point.Y);
            bool condition2 = point.X < ((polygon.Points[j].X - polygon.Points[i].X) *
                                         (point.Y - polygon.Points[i].Y) /
                                         (polygon.Points[j].Y - polygon.Points[i].Y) +
                                         polygon.Points[i].X);

            if (condition1 && condition2)
            {
                inside = !inside;
            }
        }

        return inside; 
    }

    public Polygon GetPolygonById(int id)
    {
        return _context.Polygons.Find(id);
    }
}