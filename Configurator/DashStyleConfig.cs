using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace VectorGraphicRedactor.Configurator
{
    public class DashStyleConfig : Config
    {
        private StackPanel panel;
        private ComboBox comboBox;
        public DashStyle DashStyle { get; set; }
        
        public DashStyleConfig(DashStyle dashStyle)
        {
            DashStyle = dashStyle;
            
            comboBox = new ComboBox
            {
                Height = 30,
                SelectedItem = "Solid",
                Text = "Style",
                VerticalContentAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center
            };
            
            comboBox.Items.Add("Solid");
            comboBox.Items.Add("Dot");
            comboBox.Items.Add("Dash");
            comboBox.Items.Add("DashDot");
            comboBox.Items.Add("DashDotDot");

            panel = new StackPanel()
            {
                Width = 140,
                Height = 60
            };

            panel.Children.Add(new TextBlock()
            {
                Text = "Dash Style",
                TextAlignment = TextAlignment.Center
            });
            
            panel.Children.Add(comboBox);

            View = panel;
            comboBox.SelectionChanged += ComboBoxDashStyle_SelectionChanged;
        }

        private void ComboBoxDashStyle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox.SelectedIndex == 0)
            {
                DashStyle = DashStyles.Solid;
            }
            if (comboBox.SelectedIndex == 1)
            {
                DashStyle = DashStyles.Dot;
            }
            if (comboBox.SelectedIndex == 2)
            {
                DashStyle = DashStyles.Dash;
            }
            if (comboBox.SelectedIndex == 3)
            {
                DashStyle = DashStyles.DashDot;
            }
            if (comboBox.SelectedIndex == 4)
            {
                DashStyle = DashStyles.DashDotDot;
            }
        }
    }
}