using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Media;

namespace VectorGraphicRedactor
{
    [KnownType(typeof(Rectangle))]
    [KnownType(typeof(Ellipse))]
    [KnownType(typeof(Line))]
    //[KnownType(typeof(Pie))]
    [DataContract]
    abstract class FourPointsFigure : Figure
    {
        public int X1Checked;
        public int Y1Checked;
        public int X2Checked;
        public int Y2Checked;
        
        protected Brush Brush;
        [DataMember]
        protected Brush HatchStyleData;

        protected FourPointsFigure(int x1, int y1, int x2, int y2, Brush contourColor, int thickness, DashStyle dashStyle) : base()
        {
            Pen = new Pen(contourColor, thickness) {DashStyle = dashStyle};
            X1 = X1Checked = x1;
            Y1 = Y1Checked = y1;
            X2 = X2Checked = x2;
            Y2 = Y2Checked = y2;
            ContourColor = contourColor;
            Thickness = thickness;
            DashStyleData = dashStyle;
        }
        
        protected FourPointsFigure(int x1, int y1, int x2, int y2, Brush contourColor, Color fillColor, int thickness, DashStyle dashStyle, Brush hatchStyle)
            : this(x1, y1, x2, y2, contourColor, thickness, dashStyle)
        {
            FillColor = fillColor;
            Brush = hatchStyle;
            HatchStyleData = hatchStyle;
        }
        
        public override void Resize(int xCoord, int yCoord, ViewPort camera)
        {
            Point point = ToLocalCoordinates(new Point(xCoord, yCoord), camera);
            X2 = (int) point.X;
            Y2 = (int) point.Y;
        }

        public override void SetParametersToDraw()
        { 
            Pen = new Pen(ContourColor, Thickness) {DashStyle = DashStyleData};
            Brush = HatchStyleData;
            Angle = 0;
            ScaleX = 1;
            ScaleY = 1;
            OffsetX = 0;
            OffsetY = 0;
        }

        protected virtual void CheckCoordinates(int x1, int y1, int x2, int y2)
        {
            if (x2 < x1)
            {
                X1Checked = x2;
                X2Checked = x1;
            }
            else
            {
                X1Checked = x1;
                X2Checked = x2;
            }
            
            if (y2 < y1)
            {
                Y1Checked = y2;
                Y2Checked = y1;
            }
            else
            {
                Y1Checked = y1;
                Y2Checked = y2;
            }
        }

        public override bool IntersectAnimationLayout(int x1, int y1, int x2, int y2)
        {
            CheckCoordinates(X1, Y1, X2, Y2);
            Rect rectFigure = new Rect(X1Checked, Y1Checked, X2Checked - X1Checked, Y2Checked- Y1Checked);
            Rect rectLayout = new Rect(new Point(x1, y1), new Point(x2, y2));

            return rectFigure.IntersectsWith(rectLayout);
        }
    }
}