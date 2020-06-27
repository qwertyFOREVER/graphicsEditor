using System;
using System.Collections.Generic;
using System.Configuration.Internal;
using System.IO;
using MediaColor = System.Windows.Media.Color;
using System.Runtime.Serialization.Json;
using System.Threading.Channels;
using System.Windows;
using System.Windows.Threading;

namespace VectorGraphicRedactor
{
    public class GraphicRedactor
    {
        public static DrawingObject paintSpace;
        public static LinkedList<Figure> figures;
        public ToolPicker ToolPicker;
        public ViewPort Camera;
        private DataContractJsonSerializer jsonFormatter;
        public static bool Saved;

        public static double WidthWindow;
        public static double HeightWindow; 
        
        public static bool Zoom;
        public static double ScaleX;
        public static double ScaleY;
        public static Tool.DrawingStates ToolState;
        
        private DispatcherTimer timer;

        public GraphicRedactor(DrawingObject drawingObject)
        {
            paintSpace = drawingObject;
            figures = new LinkedList<Figure>();
            
            BrushPicker.AddBrushTool(new ChessBrushTool());
            BrushPicker.AddBrushTool(new EmptyBrushTool());
            BrushPicker.AddBrushTool(new HorLinesBrushTool());
            
            ToolPicker = new ToolPicker();
            Camera = new ViewPort(0,0, 835, 602, 1); //835 602
            
            jsonFormatter = new DataContractJsonSerializer(typeof(LinkedList<Figure>));
            
            Saved = false;
            ToolState = Tool.DrawingStates.NotDrawingState;
            ScaleX = 1;
            ScaleY = 1;
            Zoom = false;
            
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Interval = new TimeSpan(0,0,0,0, 25);
            timer.Start();
        }

        public void SetWindowSize(double width, double height)
        {
            WidthWindow = width;
            HeightWindow = height;
        }

        public void SavePicture(string fileName)
        {
            using (var file = new FileStream(fileName, FileMode.Create))
            {
                Saved = true;
                jsonFormatter.WriteObject(file, figures);
            }
        }

        public void OpenPicture(string fileName)
        {
            using (var file = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                try
                {
                    var newFigures = jsonFormatter.ReadObject(file) as LinkedList<Figure>;

                    figures.Clear();
                    foreach (var figure in newFigures)
                    {
                        figures.AddLast(figure);
                        figure.SetParametersToDraw();
                    }
                    DrawImage();

                    newFigures.Clear();
                    
                    Saved = true;
                }
                catch
                {
                    MessageBox.Show("Oop! Something went wrong.\n" + 
                                    "File format does not match the file extension or file is damaged.");
                }
            }
        }

        public bool FileIsSaved()
        {
            if (figures.Count == 0)
            {
                return true;
            }

            return Saved;
        }

        public void DrawImage()
        {
            paintSpace.PaintFiguresAtWriteableBitmap(Camera);
        }
        
        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (var figure in figures)
            {
                figure.AnimateFigure();
                DrawImage();
            }
        }
    }
}