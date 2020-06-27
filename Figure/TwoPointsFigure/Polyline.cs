using System;
using System.Configuration;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Media;

namespace VectorGraphicRedactor
{
    [DataContract]
    internal class Polyline : TwoPointsFigure
    {
        private StreamGeometry geometry;
        public Polyline(int x1, int y1, Brush contourColor, int thickness, DashStyle dashStyleData) : base(x1, y1, contourColor, thickness, dashStyleData)
        {
            
        }

        public override void Draw(DrawingContext drawingContext, ViewPort camera)
        {
            geometry = new StreamGeometry();
            
            using (StreamGeometryContext ctx = geometry.Open())
            {
                ctx.BeginFigure(WorldPointsList[0], true, false);
                foreach (var element in WorldPointsList)
                {
                    ctx.LineTo(element, true, true);
                }
            }
            
            Point center = new Point()
            {
                X = geometry.Bounds.X + geometry.Bounds.Width / 2,
                Y = geometry.Bounds.Y + geometry.Bounds.Height / 2
            };
            
            drawingContext.PushTransform(new RotateTransform(Angle, center.X, center.Y));
            drawingContext.PushTransform(new ScaleTransform(ScaleX, ScaleY, center.X, center.Y));
            drawingContext.PushTransform(new TranslateTransform(OffsetX, OffsetY));
            
            drawingContext.DrawGeometry(null, Pen, geometry);
        }
    }
}