using System;
using System.Windows;
using System.Windows.Controls;

namespace VectorGraphicRedactor
{
    public class StartAngleConfig : Config
    {
        private StackPanel panel;
        public int StartAngle { get; set; }

        public StartAngleConfig(int angle)
        {
            StartAngle = angle;
            
            var textBox = new TextBox
            {
                Height = 30,
                MaxLength = 6, 
                Text = StartAngle.ToString(), 
                TextAlignment = TextAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                FontSize = 18
            };

            panel = new StackPanel()
            {
                Width = 80, 
                Height = 50,
                Margin = new Thickness(1)
            };
            
            panel.Children.Add(new TextBlock()
            {
                Text = "Start",
                TextAlignment = TextAlignment.Center
            });
            
            panel.Children.Add(textBox);

            View = panel;
            textBox.TextChanged += TextBox_TextChanged;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Int32.TryParse(((TextBox) panel.Children[1]).Text, out _))
            {
                StartAngle = Int32.Parse(((TextBox) panel.Children[1]).Text);
            }
            else
            {
                StartAngle = 0;
            }
        }
    }
}