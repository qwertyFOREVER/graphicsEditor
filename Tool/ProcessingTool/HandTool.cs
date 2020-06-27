using System.Windows;
using System.Windows.Controls;

namespace VectorGraphicRedactor
{
    public class HandTool : ProcessingTool
    {
        private int x1;
        private int y1;
        private int x2;
        private int y2;

        public HandTool()
        {
            ToolView = new Button()
            {
                Width = 60,
                Height = 30,
                Content = "Hand",
                Margin = new Thickness(7)
            };
        }
        
        public override void MouseLeftButtonDown(int xCoord, int yCoord, ViewPort camera)
        {
            x1 = xCoord;
            y1 = yCoord;
            GraphicRedactor.ToolState = DrawingStates.DrawingState;
        }

        public override void MouseMove(int xCoord, int yCoord, ViewPort camera)
        {
            x2 = xCoord;
            y2 = yCoord;
            
            if (GraphicRedactor.ToolState == DrawingStates.DrawingState)
            {
                camera.Start -= Point.Subtract(new Point(x2, y2), new Point(x1, y1)) / camera.Scale;
                camera.End -= Point.Subtract(new Point(x2, y2),new Point(x1, y1)) / camera.Scale;
                x1 = x2;
                y1 = y2;
            }
        }

        public override void MouseLeftButtonUp(ViewPort camera)
        {
            GraphicRedactor.ToolState = DrawingStates.NotDrawingState;
        }

        public override void MouseRightButtonUp(ViewPort camera, int x, int y)
        {
            //throw new System.NotImplementedException();
        }
    }
}