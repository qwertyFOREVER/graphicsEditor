using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Windows.Media;
using System.Windows;

namespace VectorGraphicRedactor
{
    [KnownType(typeof(Polyline))]
    [DataContract]
    abstract class TwoPointsFigure : Figure
    {
        [DataMember]
        public readonly List<Point> PointsList;

        public List<Point> WorldPointsList;
        private Point point;

        protected TwoPointsFigure(int x1, int y1, Brush color, int thickness, DashStyle dashStyleData) : base()
        {
            PointsList = new List<Point>();
            WorldPointsList = new List<Point>();
            Pen = new Pen(color, thickness)
            {
                DashStyle = dashStyleData
            };
            point.X = x1;
            point.Y = y1;
            PointsList.Add(point);
            PointsList.Add(point);
            ContourColor = color;
            Thickness = thickness;
            DashStyleData = dashStyleData;
        }
        
        public override void Resize(int xCoord, int yCoord, ViewPort camera)
        {
            Point point = ToLocalCoordinates(new Point(xCoord, yCoord), camera);
            PointsList.Add(point);
        }
        
        public override void SetParametersToDraw()
        {
            Pen = new Pen(ContourColor, Thickness) {DashStyle = DashStyleData};
            Angle = 0;
            ScaleX = 1;
            ScaleY = 1;
            OffsetX = 0;
            OffsetY = 0;
        }
        
        public override void ToWorldCoordinates(ViewPort camera)
        {
            if (WorldPointsList == null)
            {
                WorldPointsList = new List<Point>();
            }
            else
            {
                WorldPointsList.Clear();
            }
            
            for (int i = 0; i < PointsList.Count; i++)
            {
                var point = new Point((PointsList[i].X - camera.Start.X) * camera.Scale,
                    (PointsList[i].Y - camera.Start.Y) *camera.Scale);
                WorldPointsList.Add(point);
            }
        }
        public override bool IntersectAnimationLayout(int x1, int y1, int x2, int y2) 
        {
            foreach (var element in PointsList)
            {
                if (new Rect(new Point(x1, y1), new Point(x2, y2)).IntersectsWith(new Rect(element, element)))
                {
                    return true;
                }
            }

            return false;
        }
    }
}