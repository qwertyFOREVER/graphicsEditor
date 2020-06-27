using System;
using System.Windows;
using System.Windows.Media;

namespace VectorGraphicRedactor
{
    public class DrawingObject : FrameworkElement
    {
        private readonly VisualCollection children;

        public DrawingObject()
        {
            children = new VisualCollection(this);
        }

        public void PaintFiguresAtWriteableBitmap(ViewPort camera)
        {
            children.Clear();
        
            foreach (var element in GraphicRedactor.figures)
            {
                DrawingVisual drawingVisual = new DrawingVisual();
                var drawingContext = drawingVisual.RenderOpen();
                
                var globalFigure = element.Clone() as Figure;
                globalFigure.ToWorldCoordinates(camera);
                globalFigure.Draw(drawingContext, camera);
                
                drawingContext.Close();
                children.Add(drawingVisual);
            }
        }
        
        protected override int VisualChildrenCount => children.Count;

        protected override Visual GetVisualChild(int index)
        {
            if (index < 0 || index >= children.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return children[index];
        }
    }
}