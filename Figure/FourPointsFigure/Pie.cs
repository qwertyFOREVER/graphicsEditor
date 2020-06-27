// using System.Drawing;
// using ContourColor = System.Drawing.ContourColor;
// using System.Drawing.Drawing2D;
// using System.Runtime.Serialization;
//
// namespace VectorGraphicRedactor
// {
//     [DataContract]
//     internal class Pie : FourPointsFigure
//     {
//         [DataMember]
//         private int StartAngle;
//         private int StartAngleChecked;
//         [DataMember]
//         private int SweepAngle;
//         private int width;
//         private int height;
//         private bool horizontal;
//         private bool vertical;
//         public Pie(int x1, int y1, int x2, int y2, ContourColor color, ContourColor fillColor, int thickness, int startAngle, int sweepAngle, DashStyle dashStyle, HatchStyle hatchStyleData) 
//                         : base(x1, y1, x2, y2, color, fillColor, thickness, dashStyle, hatchStyleData)
//         {
//             StartAngle = startAngle;
//             SweepAngle = sweepAngle;
//             StartAngleChecked = StartAngle;
//         }
//         public override void Draw(Graphics g)
//         {
//             CheckCoordinates(X1, Y1, X2, Y2);
//             width = X2Checked - X1Checked;
//             height = Y2Checked - Y1Checked;
//             g.DrawPie(Pen, X1Checked, Y1Checked, width, height, StartAngleChecked, SweepAngle);
//             g.FillPie(Brush, X1Checked, Y1Checked, width, height, StartAngleChecked, SweepAngle);
//         }
//         
//         protected override void CheckCoordinates(int x1, int y1, int x2, int y2)
//         {
//             if (x2 > x1 && y2 > y1)
//             {
//                 horizontal = true;
//                 X1Checked = x1;
//                 X2Checked = x2;
//                 Y1Checked = y1;
//                 Y2Checked = y2;
//                 StartAngleChecked = StartAngle; //StartAngle
//             }
//
//             if (x2 == x1 && y2 > y1)
//             {
//                 horizontal = false;
//                 vertical = true;
//                 X1Checked = x1;
//                 X2Checked = x1 + width;
//                 Y1Checked = y1;
//                 Y2Checked = y2;
//                 StartAngleChecked = StartAngle + 90;
//                 vertical = false;
//             }
//
//             if (x2 > x1 && y2 == y1)
//             {
//                 horizontal = true;
//                 vertical = false;
//                 X1Checked = x1;
//                 X2Checked = x2;
//                 Y1Checked = y1;
//                 Y2Checked = y1 + height;
//                 StartAngleChecked = StartAngle;
//             }
//
//             if (x2 == x1 && y2 == y1)
//             {
//                 horizontal = false;
//                 vertical = false;
//                 if (width == 0)
//                 {
//                     width = Thickness;
//                 }
//
//                 if (height == 0)
//                 {
//                     height = Thickness;
//                 }
//
//                 X1Checked = x1;
//                 X2Checked = x1 + width;
//                 Y1Checked = y1;
//                 Y2Checked = y2 + height;
//             }
//             
//             if (x2 < x1 && y2 > y1)//
//             {
//                 X1Checked = x2;
//                 X2Checked = x1;
//                 Y1Checked = y1;
//                 Y2Checked = y2;
//                 if (horizontal)
//                 {
//                     StartAngleChecked = StartAngle + 180;
//                     horizontal = false;
//                 }
//                 else
//                 {
//                     StartAngleChecked = StartAngle + 90;
//                     vertical = false;
//                 }
//             }
//
//             if (x2 < x1 && y2 == y1)
//             {
//                 horizontal = false;
//                 X1Checked = x2;
//                 X2Checked = x1;
//                 Y1Checked = y1;
//                 Y2Checked = y1 + height;
//                 StartAngleChecked = StartAngle + 180;
//             }
//             if (x2 < x1 && y2 < y1)
//             {
//                 horizontal = false;
//                 X1Checked = x2;
//                 X2Checked = x1;
//                 Y1Checked = y2;
//                 Y2Checked = y1;
//                 StartAngleChecked = StartAngle + 180;
//                 vertical = true;
//             }
//
//             if (x2 == x1 && y2 < y1)
//             {
//                 horizontal = false;
//                 X1Checked = x1;
//                 X2Checked = x1 + width;
//                 Y1Checked = y2;
//                 Y2Checked = y1;
//                 StartAngleChecked = StartAngle + 270;
//                 vertical = true;
//             }
//             if (x2 > x1 && y2 < y1)
//             {
//                 horizontal = false;
//                 X1Checked = x1;
//                 X2Checked = x2;
//                 Y1Checked = y2;
//                 Y2Checked = y1;
//                 StartAngleChecked = StartAngle + 270;
//                 vertical = true;
//             }
//         }
//     }
// }