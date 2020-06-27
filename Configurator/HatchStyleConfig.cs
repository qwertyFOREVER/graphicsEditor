using System.Windows;
using System.Windows.Controls;

namespace VectorGraphicRedactor
{
    public class HatchStyleConfig : Config
    {
        private StackPanel panel;
        private ComboBox comboBox;
        public ICustomBrush HatchStyle { get; set; }
        
        public HatchStyleConfig(ICustomBrush brushTool)
        {
            HatchStyle = brushTool;
            
            comboBox = new ComboBox
            {
                Height = 30,
                SelectedItem = "Solid",
                Text = "Style",
                VerticalContentAlignment = VerticalAlignment.Center,
                HorizontalContentAlignment = HorizontalAlignment.Center
            };
            
            comboBox.Items.Add("Solid");
            comboBox.Items.Add("Chess");
            comboBox.Items.Add("Empty");
            //comboBox.Items.Add("HorizontalLines"); //TODO
            //comboBox.Items.Add("DottedGrid");
            //comboBox.Items.Add("Horizontal");

            panel = new StackPanel()
            {
                Width = 140,
                Height = 60
            };

            panel.Children.Add(new TextBlock()
            {
                Text = "Hatch Style",
                TextAlignment = TextAlignment.Center
            });

            panel.Children.Add(comboBox);

            View = panel;
            comboBox.SelectionChanged += ComboBoxHatchStyle_SelectionChanged;
        }

        private void ComboBoxHatchStyle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox.SelectedIndex == 0) //SolidBrush
            {
                BrushPicker.SetBrushTool(BrushPicker.BrushTools[0]);
            }
            if (comboBox.SelectedIndex == 1) //Chess
            {
                BrushPicker.SetBrushTool(BrushPicker.BrushTools[1]);
            }
            if (comboBox.SelectedIndex == 2) //Empty
            {
                BrushPicker.SetBrushTool(BrushPicker.BrushTools[2]);
            }
            // if (comboBox.SelectedIndex == 3) //HorizontalLines
            // {
            //     BrushPicker.SetBrushTool(BrushPicker.BrushTools[3]);
            // }
            HatchStyle = BrushPicker.GetBrushTool();
            // if (comboBox.SelectedIndex == 3)
            // {
            //     HatchStyle = HatchStyle.WideUpwardDiagonal;
            // }
            // if (comboBox.SelectedIndex == 4)
            // {
            //     HatchStyle = HatchStyle.DottedGrid;
            // }
            // if (comboBox.SelectedIndex == 5)
            // {
            //     HatchStyle = HatchStyle.Horizontal;
            // }
        }
    }
}