using System.Windows.Media;

namespace VectorGraphicRedactor
{
    public interface ICustomBrush
    {
        public Brush GetBrush(Color color);        
    }
}