using System.Windows;
using System.Windows.Media;

namespace VectorGraphicRedactor
{
    public class HorLinesBrushTool : ICustomBrush //TODO
    {
        public Brush GetBrush(Color color)
        {
            DrawingBrush chessBrush = new DrawingBrush();

            GeometryGroup aGeometryGroup = new GeometryGroup();
            aGeometryGroup.Children.Add(new LineGeometry(new Point(0, 0), new Point(100, 100)));

            SolidColorBrush checkerBrush = new SolidColorBrush(color);

            GeometryDrawing checkers = new GeometryDrawing(checkerBrush, null, aGeometryGroup);

            DrawingGroup checkersDrawingGroup = new DrawingGroup();
            checkersDrawingGroup.Children.Add(checkers);

            chessBrush.Drawing = checkersDrawingGroup;
            chessBrush.Viewport = new Rect(0, 0, 0.25, 0.25);
            chessBrush.TileMode = TileMode.Tile;

            return chessBrush;
        }
    }
}