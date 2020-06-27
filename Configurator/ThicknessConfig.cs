using System.Windows;
using System.Windows.Controls;

namespace VectorGraphicRedactor
{
    public class ThicknessConfig : Config
    {
        private StackPanel panel;
        public int Thickness { get; set; }

        public ThicknessConfig(int thickness)
        {
            Thickness = thickness;
            
            var slider = new Slider
            {
                Height = 20,
                Value = 2,
                Minimum = 2, 
                Maximum = 50,
                VerticalContentAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center
            };
            
            panel = new StackPanel()
            {
                Width = 120, 
                Height = 60,
                Margin = new Thickness(3)
            };
            
            panel.Children.Add(new TextBlock()
            {
                Text = "Thickness", 
                TextAlignment = TextAlignment.Center
            });
            
            panel.Children.Add(slider);
            
            panel.Children.Add(new Label()
            {
                Height = 30,
                Content = "2", 
                HorizontalContentAlignment = HorizontalAlignment.Center
            });

            View = panel;
            slider.ValueChanged += Slider_ValueChanged;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((Label) panel.Children[2]).Content = ((int)e.NewValue).ToString();
            Thickness = (int)e.NewValue;
        }
    }
}