using System.Windows.Media;

namespace VectorGraphicRedactor
{
    interface IDrawable
    {
        void Draw(DrawingContext drawingContext, ViewPort camera);
        void Resize(int xCoordinate, int yCoordinate, ViewPort camera);
    }
}