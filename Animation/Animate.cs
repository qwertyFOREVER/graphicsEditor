using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using VectorGraphicRedactor.Configurator;

namespace VectorGraphicRedactor
{
    public class Animate : ProcessingTool
    {
        private Figure animationLayout;
        
        private RotationConfig rotationConfig;
        private PulseAnimationConfig pusleAnimationConfig;
        private TranslateAnimationConfig translateAnimationConfig;
        public RotationConfig RotationConfig { get => rotationConfig; set => rotationConfig = value; }
        public PulseAnimationConfig PulseAnimationConfig { get => pusleAnimationConfig; set => pusleAnimationConfig = value; }
        public TranslateAnimationConfig TranslateAnimationConfig { get => translateAnimationConfig; set => translateAnimationConfig = value; }
        public Animate()
        {
            RotationConfig = new RotationConfig(0);
            PulseAnimationConfig = new PulseAnimationConfig(0);
            TranslateAnimationConfig = new TranslateAnimationConfig(0);

            ToolView = new Button()
            {
                Width = 60,
                Height = 30,
                Content = "Animate!",
                Margin = new Thickness(7)
            };
        }

        public override void MouseLeftButtonDown(int xCoord, int yCoord, ViewPort camera)
        {
            animationLayout = new Rectangle((int)xCoord, (int)yCoord, (int)xCoord, 
                (int)yCoord, new SolidColorBrush(Colors.Aqua), Colors.Black, 
                5, DashStyles.Dot, new SolidColorBrush());
            
            animationLayout.ToLocalCoordinates(camera);
            
            GraphicRedactor.figures.AddLast(animationLayout);
            
            GraphicRedactor.ToolState = DrawingStates.DrawingState;
        }
        
        public override void MouseMove(int xCoord, int yCoord, ViewPort camera)
        {
            if (GraphicRedactor.ToolState == DrawingStates.DrawingState)
            {
                GraphicRedactor.figures.Last.Value.Resize(xCoord, yCoord, camera);
            }
        }

        public override void MouseLeftButtonUp(ViewPort camera)
        {            Console.WriteLine(GraphicRedactor.figures.Last.Value.X1);
            Console.WriteLine(GraphicRedactor.figures.Last.Value.Y1);
            Console.WriteLine(GraphicRedactor.figures.Last.Value.X2);
            Console.WriteLine(GraphicRedactor.figures.Last.Value.Y2);
            GraphicRedactor.ToolState = DrawingStates.NotDrawingState;
            GraphicRedactor.figures.RemoveLast();
            AnimateSelectedFigures(animationLayout.X1, animationLayout.Y1, animationLayout.X2, animationLayout.Y2);
        }
        public override void MouseRightButtonUp(ViewPort camera, int x, int y)
        {
            
        }

        private void AnimateSelectedFigures(int x1, int y1, int x2, int y2)
        {
            foreach (var figure in GraphicRedactor.figures)
            {
                if (figure.IntersectAnimationLayout(x1, y1, x2, y2))
                {
                    if (rotationConfig.Speed != 0)
                    {
                        figure.AddAnimation(new RotationAnimation(rotationConfig.Speed));
                    }
                    if (pusleAnimationConfig.Intensity != 0)
                    {
                        figure.AddAnimation(new PulseAnimation(PulseAnimationConfig.Intensity));
                    }
                    if (translateAnimationConfig.Radius != 0)
                    {
                        figure.AddAnimation(new TranslateAnimation(translateAnimationConfig.Radius));
                    }
                }
            }
        }
    }
}