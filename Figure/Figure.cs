using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Media;

namespace VectorGraphicRedactor
{
    [KnownType(typeof(TranslateAnimation))]
    [KnownType(typeof(RotationAnimation))]
    [KnownType(typeof(PulseAnimation))]
    
    [KnownType(typeof(SolidColorBrush))]
    [KnownType(typeof(MatrixTransform))]
    [KnownType(typeof(DrawingBrush))]
    [KnownType(typeof(DrawingGroup))]
    [KnownType(typeof(GeometryDrawing))]
    [KnownType(typeof(RectangleGeometry))]
    [KnownType(typeof(LinearGradientBrush))]
    [KnownType(typeof(GeometryGroup))]
    
    [KnownType(typeof(Rectangle))]
    [KnownType(typeof(Ellipse))]
    [KnownType(typeof(Line))]
    // [KnownType(typeof(Pie))]
    [KnownType(typeof(Polyline))]
    [DataContract]
    public abstract class Figure : IDrawable
    {
        [DataMember]
        public int X1;
        [DataMember]
        public int Y1;
        [DataMember]
        public int X2;
        [DataMember]
        public int Y2;
        [DataMember]
        public Brush ContourColor;
        [DataMember]
        protected Color FillColor;
        [DataMember]
        protected int Thickness;
        [DataMember]
        protected DashStyle DashStyleData;

        public double Angle;
        public double ScaleX;
        public double ScaleY;
        public double OffsetX;
        public double OffsetY;

        public Pen Pen;
        
        [DataMember]
        public List<IAnimatable> Transformations;

        protected Figure()
        {
            Transformations = new List<IAnimatable>();
            Angle = 0;
            ScaleX = 1;
            ScaleY = 1;
            OffsetX = 0;
            OffsetY = 0;
        }

        public abstract void Draw(DrawingContext drawingContext, ViewPort camera);

        public abstract void Resize(int xCoord, int yCoord, ViewPort camera);

        public abstract void SetParametersToDraw();
        
        public abstract bool IntersectAnimationLayout(int x1, int y1, int x2, int y2);

        public void AddAnimation(IAnimatable animation)
        {
            Transformations.Add(animation);
        }

        public void AnimateFigure()
        {
            foreach (var animation in Transformations)
            {
                animation.Tick(this);
            }
        }
        public Point ToLocalCoordinates(Point point, ViewPort camera) => new Point(point.X / camera.Scale + camera.Start.X, point.Y / camera.Scale + camera.Start.Y);

        public virtual void ToWorldCoordinates(ViewPort camera)
        {
            X1 = (int) ((X1 - camera.Start.X) * camera.Scale);
            Y1 = (int) ((Y1 - camera.Start.Y) * camera.Scale);
            X2 = (int) ((X2 - camera.Start.X) * camera.Scale);
            Y2 = (int) ((Y2 - camera.Start.Y) * camera.Scale);
        }

        public void ToLocalCoordinates(ViewPort camera)
        {
            X1 = (int) (X1 / camera.Scale + camera.Start.X);
            Y1 = (int) (Y1 / camera.Scale + camera.Start.Y);
            X2 = (int) (X2 / camera.Scale + camera.Start.X);
            Y2 = (int) (Y2 / camera.Scale + camera.Start.Y);
        }

        public object Clone() => MemberwiseClone();
    }
}