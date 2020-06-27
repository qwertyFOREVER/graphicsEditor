using System.Drawing.Drawing2D;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using VectorGraphicRedactor.Configurator;

namespace VectorGraphicRedactor
{
    public class LineTool : DrawingTool
    {
        private ContourColorConfig contourColorConfig;
        private ThicknessConfig thicknessConfig;
        private DashStyleConfig dashStyleConfig;
        private HatchStyleConfig hatchStyleConfig;
        
        public ContourColorConfig ContourColorConfig
        {
            get => contourColorConfig;
            set => contourColorConfig = value;
        }
        public ThicknessConfig ThicknessConfig
        {
            get => thicknessConfig;
            set => thicknessConfig = value;
        }
        public DashStyleConfig DashStyleConfig
        {
            get => dashStyleConfig;
            set => dashStyleConfig = value;
        }
        public HatchStyleConfig HatchStyleConfig
        {
            get => hatchStyleConfig;
            set => hatchStyleConfig = value;
        }
        
        public LineTool()
        {
            ContourColorConfig = new ContourColorConfig(Colors.Violet);
            ThicknessConfig = new ThicknessConfig(2);
            DashStyleConfig = new DashStyleConfig(DashStyles.Solid);
            HatchStyleConfig = new HatchStyleConfig(BrushPicker.GetBrushTool());
            
            ToolView = new Button()
            {
                Width = 60,
                Height = 30,
                Content = "Line",
                Margin = new Thickness(7)
            };
        }
        
        public override Figure CreateFigure(int x1, int y1, int x2, int y2)
        {
            return new Line(x1, y1, x2, y2, contourColorConfig.ContourColor, thicknessConfig.Thickness, dashStyleConfig.DashStyle);
        }
    }
}