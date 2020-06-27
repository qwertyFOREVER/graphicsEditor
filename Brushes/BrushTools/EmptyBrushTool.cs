using System.Windows.Media;

namespace VectorGraphicRedactor
{
    public class EmptyBrushTool : ICustomBrush
    {
        public Brush GetBrush(Color color)
        {
            return new SolidColorBrush();
        }
    }
}