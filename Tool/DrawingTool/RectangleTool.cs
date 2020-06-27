using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using VectorGraphicRedactor.Configurator;

namespace VectorGraphicRedactor
{
    public class RectangleTool : DrawingTool
    {
        private ContourColorConfig contourColorConfig;
        private FillColorConfig fillColorConfig;
        private ThicknessConfig thicknessConfig;
        private DashStyleConfig dashStyleConfig;
        private HatchStyleConfig hatchStyleConfig;
        
        public ContourColorConfig ContourColorConfig { get => contourColorConfig; set => contourColorConfig = value; }
        public FillColorConfig FillColorConfig { get => fillColorConfig; set => fillColorConfig = value; }
        public ThicknessConfig ThicknessConfig { get => thicknessConfig; set => thicknessConfig = value; }
        public DashStyleConfig DashStyleConfig { get => dashStyleConfig; set => dashStyleConfig = value; }
        public HatchStyleConfig HatchStyleConfig { get => hatchStyleConfig; set => hatchStyleConfig = value; }

        public RectangleTool()
        {
            ContourColorConfig = new ContourColorConfig(Colors.Violet);
            FillColorConfig = new FillColorConfig(Colors.Aquamarine);
            ThicknessConfig = new ThicknessConfig(2);
            DashStyleConfig = new DashStyleConfig(DashStyles.Solid);
            HatchStyleConfig = new HatchStyleConfig(BrushPicker.GetBrushTool());

            ToolView = new Button()
            {
                Width = 60,
                Height = 30,
                Content = "Rectangle",
                Margin = new Thickness(7)
            };
        }
        
        public override Figure CreateFigure(int x1, int y1, int x2, int y2)
        {
            return new Rectangle(x1, y1, x2, y2, contourColorConfig.ContourColor, fillColorConfig.Color, 
                thicknessConfig.Thickness, dashStyleConfig.DashStyle, hatchStyleConfig.HatchStyle.GetBrush(fillColorConfig.Color));
        }
    }
}