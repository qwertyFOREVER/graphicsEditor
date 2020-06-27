using System.Windows;
using System.Windows.Controls;
using Xceed.Wpf.Toolkit;
using System.Windows.Media;

namespace VectorGraphicRedactor
{
    public class ContourColorConfig : Config
    {
        private StackPanel panel;
        public Brush ContourColor { get; set; }

        public ContourColorConfig(Color color)
        {
            ContourColor = GetBrush(color);
            
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
                Text = "Contour",
                TextAlignment = TextAlignment.Center
            });

            panel.Children.Add(colorPicker);

            View = panel;
            colorPicker.SelectedColorChanged += ColorPicker_SelectedColorChanged;
        }

        private void ColorPicker_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            if (e.NewValue != null)
            {
                ContourColor = GetBrush((Color) e.NewValue);
            }
        }

        private Brush GetBrush(Color color)
        {
            return new SolidColorBrush(color);
        }
    }
}