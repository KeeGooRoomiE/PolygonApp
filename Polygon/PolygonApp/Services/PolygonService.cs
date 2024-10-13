using PolygonApp.Models;

namespace PolygonApp.Services
{
    public class PolygonService
    {
        private readonly List<Polygon> _polygons = new List<Polygon>();
        private int _nextId = 1;
        
        private int _counter = 0;

        // Метод для увеличения числа
        public int IncrementCounter()
        {
            _counter++;
            return _counter;
        }

        // Создание полигона
        public Polygon CreatePolygon(List<Point> points)
        {
            var polygon = new Polygon
            {
                Id = _nextId++,
                Points = points
            };
            _polygons.Add(polygon);
            return polygon;
        }

        // Поиск полигона по ID
        public Polygon GetPolygonById(int id)
        {
            return _polygons.FirstOrDefault(p => p.Id == id);
        }

        // Проверка точки внутри полигона
        public bool IsPointInPolygon(Point point, Polygon polygon)
        {
            bool inside = false;
            int count = polygon.Points.Count;

            for (int i = 0; i < count; i++)
            {
                int j = (i + 1) % count;

                if ((polygon.Points[i].Y > point.Y) != (polygon.Points[j].Y > point.Y) &&
                    (point.X < (polygon.Points[j].X - polygon.Points[i].X) * (point.Y - polygon.Points[i].Y) /
                        (polygon.Points[j].Y - polygon.Points[i].Y) + polygon.Points[i].X))
                {
                    inside = !inside;
                }
            }

            return inside;
        }
    }
}