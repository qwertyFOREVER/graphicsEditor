using System;
using MediaColor = System.Windows.Media.Color;

namespace VectorGraphicRedactor
{
    public abstract class DrawingTool : Tool
    {
        public abstract Figure CreateFigure(int x1, int y1, int x2, int y2);
        
        #region MouseHandler
        public override void MouseLeftButtonDown(int xCoord, int yCoord, ViewPort camera)
        {
            GraphicRedactor.Saved = false;
            GraphicRedactor.figures.AddLast(CreateFigure((int)xCoord, (int)yCoord, (int)xCoord, 
                (int)yCoord));
            GraphicRedactor.figures.Last.Value.ToLocalCoordinates(camera);

            GraphicRedactor.ToolState = DrawingStates.DrawingState;
        }
        public override void MouseMove(int xCoord, int yCoord, ViewPort camera)
        {
            if (GraphicRedactor.ToolState == DrawingStates.DrawingState)
            {
                GraphicRedactor.figures.Last.Value.Resize(xCoord, yCoord, camera);
            }
        }
        public override void MouseLeftButtonUp(ViewPort camera)
        {
            GraphicRedactor.ToolState = DrawingStates.NotDrawingState;
        }
        public override void MouseRightButtonUp(ViewPort camera, int x, int y)
        {
            
        }

        #endregion
    }
}