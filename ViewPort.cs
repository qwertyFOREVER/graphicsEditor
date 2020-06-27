using System.Windows;

namespace VectorGraphicRedactor
{
    public class ViewPort
    {
        public Point Start { get; set; }
        public Point End { get; set; }
        public double Scale { get; set; }

        public ViewPort(int x1, int y1, int x2, int y2, double scale)
        {
            Start = new Point(x1, y1);
            End = new Point(x2, y2);
            Scale = scale;
        }
    }
}