using System.Windows;
using System.Windows.Controls;
using Xceed.Wpf.Toolkit;
using System.Windows.Media;

namespace VectorGraphicRedactor
{
    public class FillColorConfig : Config
    {
        private StackPanel panel;
        public Color Color { get; set; }

        public FillColorConfig(Color color)
        {
            Color = color;
            
            var colorPicker = new ColorPicker
            {
                Height = 30,
                SelectedColor = color
            };

            panel = new StackPanel()
            {
                Width = 140,
                Height = 60,
                Margin = new Thickness(5)
            };

            panel.Children.Add(new TextBlock()
            {
                Text = "Fill",
                TextAlignment = TextAlignment.Center
            });

            panel.Children.Add(colorPicker);

            View = panel;
            colorPicker.SelectedColorChanged += ColorPicker_SelectedFillColorChanged;
        }

        private void ColorPicker_SelectedFillColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if (e.NewValue != null) Color = (Color) e.NewValue;
        }
    }
}