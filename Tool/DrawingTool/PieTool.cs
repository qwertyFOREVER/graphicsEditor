// using System.Drawing.Drawing2D;
// using System.Windows;
// using System.Windows.Controls;
// using System.Windows.Media;
// using VectorGraphicRedactor.Configurator;
// using ContourColor = System.Drawing.ContourColor;
// using DashStyle = System.Drawing.Drawing2D.DashStyle;
//
// namespace VectorGraphicRedactor
// {
//     public class PieTool : DrawingTool
//     {
//         private ContourColorConfig contourColorConfig;
//         private FillColorConfig fillColorConfig;
//         private ThicknessConfig thicknessConfig;
//         private StartAngleConfig startAngleConfig;
//         private SweepAngleConfig sweepAngleConfig;
//         private DashStyleConfig dashStyleConfig;
//         private HatchStyleConfig hatchStyleConfig;
//
//         public ContourColorConfig ContourColorConfig { get => contourColorConfig; set => contourColorConfig = value; }
//         public FillColorConfig FillColorConfig { get => fillColorConfig; set => fillColorConfig = value; }
//         public ThicknessConfig ThicknessConfig { get => thicknessConfig; set => thicknessConfig = value; }
//         public StartAngleConfig StartAngleConfig { get => startAngleConfig; set => startAngleConfig = value; }
//         public SweepAngleConfig SweepAngleConfig { get => sweepAngleConfig; set => sweepAngleConfig = value; }
//         public DashStyleConfig DashStyleConfig { get => dashStyleConfig; set => dashStyleConfig = value; }
//         
//         public HatchStyleConfig HatchStyleConfig { get => hatchStyleConfig; set => hatchStyleConfig = value; }
//
//         public PieTool()
//         {
//             ContourColorConfig = new ContourColorConfig(Colors.Violet);
//             FillColorConfig = new FillColorConfig(Colors.Aquamarine);
//             ThicknessConfig = new ThicknessConfig(2);
//             StartAngleConfig = new StartAngleConfig(50);
//             SweepAngleConfig = new SweepAngleConfig(240);
//             DashStyleConfig = new DashStyleConfig(DashStyle.Solid);
//             HatchStyleConfig = new HatchStyleConfig(HatchStyle.Percent05);
//             
//             ToolView = new Button()
//             {
//                 Width = 60,
//                 Height = 30,
//                 Content = "Pie",
//                 Margin = new Thickness(7)
//             };
//         }
//         
//         public override Figure CreateFigure(int x1, int y1, int x2, int y2)
//         {
//             return new Pie(x1, y1, x2, y2, contourColorConfig.ContourColor, fillColorConfig.ContourColor, 
//                             thicknessConfig.Thickness, startAngleConfig.StartAngle, sweepAngleConfig.SweepAngle,
//                             dashStyleConfig.DashStyle, hatchStyleConfig.HatchStyle);
//         }
//     }
// }