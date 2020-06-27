using System.Windows;
using System.Windows.Media;

namespace VectorGraphicRedactor
{
    public class ChessBrushTool : ICustomBrush
    {
        public Brush GetBrush(Color color)
        {
            DrawingBrush chessBrush = new DrawingBrush();

            GeometryDrawing backgroundSquare =
                new GeometryDrawing(
                    Brushes.White,
                    null,
                    new RectangleGeometry(new Rect(0, 0, 100, 100)));

            GeometryGroup aGeometryGroup = new GeometryGroup();
            aGeometryGroup.Children.Add(new RectangleGeometry(new Rect(0, 0, 50, 50)));
            aGeometryGroup.Children.Add(new RectangleGeometry(new Rect(50, 50, 50, 50)));

            LinearGradientBrush checkerBrush = new LinearGradientBrush();
            checkerBrush.GradientStops.Add(new GradientStop(color, 0.0));
            checkerBrush.GradientStops.Add(new GradientStop(Colors.Silver, 1.0));

            GeometryDrawing checkers = new GeometryDrawing(checkerBrush, null, aGeometryGroup);

            DrawingGroup checkersDrawingGroup = new DrawingGroup();
            checkersDrawingGroup.Children.Add(backgroundSquare);
            checkersDrawingGroup.Children.Add(checkers);

            chessBrush.Drawing = checkersDrawingGroup;
            chessBrush.Viewport = new Rect(0, 0, 0.25, 0.25);
            chessBrush.TileMode = TileMode.Tile;

            return chessBrush;
        }
    }
}