using System.Windows.Media;

namespace VectorGraphicRedactor
{
    public class SolidBrushTool : ICustomBrush
    {
        public Brush GetBrush(Color color)
        {
            return new SolidColorBrush(color);
        }
    }
}