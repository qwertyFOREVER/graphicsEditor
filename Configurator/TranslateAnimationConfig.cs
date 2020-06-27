using System.Windows;
using System.Windows.Controls;

namespace VectorGraphicRedactor.Configurator
{
    public class TranslateAnimationConfig : Config
    {
        private StackPanel panel;
        public double Radius { get; set; }

        public TranslateAnimationConfig(double radius)
        {
            Radius = radius;
            
            var slider = new Slider
            {
                Height = 20,
                Value = 0,
                Minimum = 0, 
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
                Text = "Translation", 
                TextAlignment = TextAlignment.Center
            });
            
            panel.Children.Add(slider);
            
            panel.Children.Add(new Label()
            {
                Height = 30,
                Content = "0", 
                HorizontalContentAlignment = HorizontalAlignment.Center
            });

            View = panel;
            slider.ValueChanged += Slider_ValueChanged;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((Label) panel.Children[2]).Content = ((int)e.NewValue).ToString();
            Radius = e.NewValue;
        }
    }
}