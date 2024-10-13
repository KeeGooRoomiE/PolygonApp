using Microsoft.EntityFrameworkCore;
using PolygonApp.Models;

public class PolygonContext : DbContext
{
    public PolygonContext(DbContextOptions<PolygonContext> options) : base(options) { }

    public DbSet<Polygon> Polygons { get; set; }
}