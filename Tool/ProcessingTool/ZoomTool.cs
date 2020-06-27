using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace VectorGraphicRedactor
{
    public class ZoomTool : ProcessingTool
    {
        private int x1;
        private int y1;
        private int x2;
        private int y2;

        public ZoomTool()
        {
            ToolView = new Button()
            {
                Width = 60,
                Height = 30,
                Content = "Zoom",
                Margin = new Thickness(7)
            };
        }

        public override void MouseLeftButtonDown(int xCoord, int yCoord, ViewPort camera)
        {
            Figure zoomLayout = new Rectangle(xCoord, yCoord, xCoord, 
                yCoord, new SolidColorBrush(Colors.Aqua), Colors.Black, 
                5, DashStyles.Solid, new SolidColorBrush());
            
            zoomLayout.ToLocalCoordinates(camera);

            GraphicRedactor.figures.AddLast(zoomLayout);

            x1 = zoomLayout.X1;
            y1 = zoomLayout.Y1;
            x2 = zoomLayout.X2;
            y2 = zoomLayout.Y2;

            GraphicRedactor.ToolState = DrawingStates.DrawingState;
        }
        
        public override void MouseMove(int xCoord, int yCoord, ViewPort camera)
        {
            if (GraphicRedactor.ToolState == DrawingStates.DrawingState)
            {
                GraphicRedactor.figures.Last.Value.Resize(xCoord, yCoord, camera);
                x2 = GraphicRedactor.figures.Last.Value.X2;
                y2 = GraphicRedactor.figures.Last.Value.Y2;
            }
        }

        public override void MouseLeftButtonUp(ViewPort camera)
        {
            GraphicRedactor.figures.RemoveLast();
            GraphicRedactor.ToolState = DrawingStates.NotDrawingState;
            if (camera.Scale > 50)
            {
                return;
            }

            if (Point.Subtract(new Point(x1, y1), new Point(x2, y2)).Length > 2)
            {
                double scaleX = (camera.End.X - camera.Start.X) / (x2 - x1);
                double scaleY = (camera.End.Y - camera.Start.Y) / (y2 - y1);
                double scale = (scaleX + scaleY) / 2;

                camera.Scale *= scale;
                camera.Start = new Point(x1, y1);
                camera.End = new Point(x2, y2);
            }
            else
            {               
                double NewWidth = (camera.End.X - camera.Start.X) / 2;
                double NewHeight = (camera.End.Y - camera.Start.Y) / 2;
                
                camera.Start = new Point()
                {
                    X = x1 - NewWidth / 2,
                    Y = y1 - NewHeight / 2
                };
                
                camera.End = new Point()
                {
                    X = camera.Start.X + NewWidth,
                    Y = camera.Start.Y + NewHeight
                };
                camera.Scale *= 2;
            }
        }

        public override void MouseRightButtonUp(ViewPort camera, int x, int y)
        {
            x1 = x;
            y1 = y;
            
            if (camera.Scale > 0.1)
            {
                double NewWidth = (camera.End.X - camera.Start.X) * 2;
                double NewHeight = (camera.End.Y - camera.Start.Y) * 2;
                    
                camera.Start = new Point()
                {
                    X = x1 / camera.Scale + camera.Start.X - NewWidth / 2,
                    Y = y1 / camera.Scale + camera.Start.Y - NewHeight / 2
                };
                camera.End = new Point()
                {
                    X = camera.Start.X + NewWidth,
                    Y = camera.Start.Y + NewHeight
                };
                camera.Scale /= 2;
            }
        }
    }
}