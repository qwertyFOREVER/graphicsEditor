using System;
using System.Windows.Media;
using System.Runtime.Serialization;
using System.Windows;

namespace VectorGraphicRedactor
{
    [DataContract]
    internal class Rectangle : FourPointsFigure
    {
        public Rectangle(int x1, int y1, int x2, int y2, Brush contourColor, Color fillColor, int thickness, DashStyle dashStyle, Brush hatchStyle) 
                : base(x1, y1, x2, y2, contourColor, fillColor, thickness, dashStyle, hatchStyle)
        {
            
        }
        public override void Draw(DrawingContext drawingContext, ViewPort camera)
        {
            CheckCoordinates(X1, Y1, X2, Y2);

            Point center = new Point((X1Checked + X2Checked) / 2, (Y1Checked + Y2Checked) / 2);
            
            drawingContext.PushTransform(new RotateTransform(Angle, center.X, center.Y));
            drawingContext.PushTransform(new ScaleTransform(ScaleX, ScaleY, center.X, center.Y));
            drawingContext.PushTransform(new TranslateTransform(OffsetX, OffsetY));

            drawingContext.DrawRectangle(Brush, Pen, new Rect(X1Checked, Y1Checked, X2Checked - X1Checked, Y2Checked - Y1Checked));
        }
    }
}