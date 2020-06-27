using System.Windows;

namespace VectorGraphicRedactor
{
    public abstract class Tool
    {
        public UIElement ToolView { get; set; }
        public enum DrawingStates
        {
            DrawingState,
            NotDrawingState
        }

        public abstract void MouseLeftButtonDown(int xCoord, int yCoord, ViewPort camera);

        public abstract void MouseMove(int xCoord, int yCoord, ViewPort camera);

        public abstract void MouseLeftButtonUp(ViewPort camera);

        public abstract void MouseRightButtonUp(ViewPort camera, int x, int y);
    }
}