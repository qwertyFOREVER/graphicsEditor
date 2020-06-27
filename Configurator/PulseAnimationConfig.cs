using System;
using System.Windows;
using System.Windows.Controls;

namespace VectorGraphicRedactor
{
    public class PulseAnimationConfig : Config
    {
        private StackPanel panel;
        public double Intensity { get; set; }

        public PulseAnimationConfig(double intensity)
        {
            Intensity = intensity;
            
            var slider = new Slider
            {
                Height = 20,
                Value = 0,
                Minimum = 0, 
                Maximum = 10,
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
                Text = "Pulsation", 
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
            ((Label) panel.Children[2]).Content = Math.Round(e.NewValue, 2).ToString();
            Intensity = e.NewValue;
        }
    }
}