using System;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Media;
using DashStyle = System.Windows.Media.DashStyle;

namespace VectorGraphicRedactor
{
    [DataContract]
    internal class Ellipse : FourPointsFigure
    {
        private Point center;
        public Ellipse(int x1, int y1, int x2, int y2, Brush contourColor, Color fillColor, int thickness, DashStyle dashStyle, Brush hatchStyle) 
                        : base(x1, y1, x2, y2, contourColor, fillColor, thickness, dashStyle, hatchStyle)
        {

        }
        public override void Draw(DrawingContext drawingContext, ViewPort camera)
        {
            CheckCoordinates(X1, Y1, X2, Y2);
            
            center.X = (X1Checked + X2Checked) / 2;
            center.Y = (Y1Checked + Y2Checked) / 2;
            
            drawingContext.PushTransform(new RotateTransform(Angle, center.X, center.Y));
            drawingContext.PushTransform(new ScaleTransform(ScaleX, ScaleY, center.X, center.Y));
            drawingContext.PushTransform(new TranslateTransform(OffsetX, OffsetY));
            
            drawingContext.DrawEllipse(Brush, Pen, center, center.X - X1Checked, center.Y - Y1Checked);
        }
    }
}