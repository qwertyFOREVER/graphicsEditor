using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using VectorGraphicRedactor.Configurator;

namespace VectorGraphicRedactor
{
    public class PencilTool : DrawingTool
    {
        private ContourColorConfig contourColorConfig;
        private ThicknessConfig thicknessConfig;
        private DashStyleConfig dashStyleConfig;

        public ContourColorConfig ContourColorConfig { get => contourColorConfig; set => contourColorConfig = value; }
        public ThicknessConfig ThicknessConfig { get => thicknessConfig; set => thicknessConfig = value; }
        public DashStyleConfig DashStyleConfig { get => dashStyleConfig; set => dashStyleConfig = value; }

        public PencilTool()
        {
            ContourColorConfig = new ContourColorConfig(Colors.Violet);
            ThicknessConfig = new ThicknessConfig(2);
            DashStyleConfig = new DashStyleConfig(DashStyles.Solid);

            ToolView = new Button()
            {
                Width = 60,
                Height = 30,
                Content = "Pencil",
                Margin = new Thickness(7)
            };
        }
        
        public override Figure CreateFigure(int x1, int y1, int x2, int y2)
        {
            return new Polyline(x1, y1, contourColorConfig.ContourColor, thicknessConfig.Thickness, dashStyleConfig.DashStyle);
        }
        
        public override void MouseLeftButtonDown(int xCoord, int yCoord, ViewPort camera)
        {
            GraphicRedactor.Saved = false;
            
            int x = (int)(xCoord / camera.Scale + camera.Start.X);
            int y = (int)(yCoord / camera.Scale + camera.Start.Y);
            
            GraphicRedactor.figures.AddLast(CreateFigure(x, y, x, y));

            GraphicRedactor.ToolState = DrawingStates.DrawingState;
        }
    }
}