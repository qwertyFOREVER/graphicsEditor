using System;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Media;

namespace VectorGraphicRedactor
{
    [DataContract]
    internal class Line : FourPointsFigure
    {
        private Point start;
        private Point end;
        
        public Line(int x1, int y1, int x2, int y2, Brush color, int thickness, DashStyle dashStyle) 
                        : base(x1, y1, x2, y2, color, thickness, dashStyle) 
        {
            
        }
        public override void Draw(DrawingContext drawingContext, ViewPort camera)
        {
            start.X = X1;
            start.Y = Y1;
            end.X = X2;
            end.Y = Y2;

            drawingContext.PushTransform(new RotateTransform(Angle, (start.X + end.X) / 2, (start.Y + end.Y) / 2));
            drawingContext.PushTransform(new ScaleTransform(ScaleX, ScaleY, (start.X + end.X) / 2, (start.Y + end.Y) / 2));
            drawingContext.PushTransform(new TranslateTransform(OffsetX, OffsetY));
            
            drawingContext.DrawLine(Pen, start, end);
        }
    }
}