using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using MediaColor = System.Windows.Media.Color;

namespace VectorGraphicRedactor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly GraphicRedactor graphicRedactor;
        public MainWindow()
        {
            InitializeComponent();
            graphicRedactor = new GraphicRedactor(DrawingObject);
            
            graphicRedactor.ToolPicker.AddTool(new PencilTool());
            graphicRedactor.ToolPicker.AddTool(new RectangleTool());
            graphicRedactor.ToolPicker.AddTool(new EllipseTool());
            graphicRedactor.ToolPicker.AddTool(new LineTool());
            graphicRedactor.ToolPicker.AddTool(new HandTool());
            graphicRedactor.ToolPicker.AddTool(new ZoomTool());
            graphicRedactor.ToolPicker.AddTool(new Animate());
            // graphicRedactor.ToolPicker.AddTool(new PieTool());
            
            graphicRedactor.ToolPicker.SetView(ToolPanel, ConfigPanel);
            Picture.AddHandler(MouseLeftButtonDownEvent, new MouseButtonEventHandler(Picture_MouseLeftButtonDown), true);
        }

        #region MouseHandler

        private void Picture_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Mouse.Capture(Picture);
            var coords = e.GetPosition(Picture);

            graphicRedactor.ToolPicker.GetTool().MouseLeftButtonDown((int)coords.X, (int)coords.Y, graphicRedactor.Camera);
            graphicRedactor.DrawImage();
        }

        private void Picture_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Mouse.Capture(null);
            graphicRedactor.ToolPicker.GetTool().MouseLeftButtonUp(graphicRedactor.Camera);
        }

        private void Picture_MouseMove(object sender, MouseEventArgs e)
        {
            var coords = e.GetPosition(Picture);
            graphicRedactor.ToolPicker.GetTool().MouseMove((int) coords.X, (int) coords.Y, graphicRedactor.Camera);
            graphicRedactor.DrawImage();
        }

        private void Picture_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            var coords = e.GetPosition(Picture);
            graphicRedactor.ToolPicker.GetTool().MouseRightButtonUp(graphicRedactor.Camera, (int)coords.X, (int)coords.Y);
        }

        #endregion

        #region WindowHandler

        private void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            if (graphicRedactor.FileIsSaved())
            {
                e.Cancel = false;
            }
            else
            {
                var messageBoxResult = MessageBox.Show("Do you want to save the file first?", 
                    "Save", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    SaveFileProcess();
                    e.Cancel = true;
                }
                else if (messageBoxResult == MessageBoxResult.No)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
        
        private void Picture_OnLoaded(object sender, RoutedEventArgs e)
        {
            graphicRedactor.SetWindowSize(Picture.ActualWidth, Picture.ActualHeight);
        }

        #endregion

        #region FileHandler
        
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileProcess();
        }
        
        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Json File(*.json) | *json";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {
                graphicRedactor.OpenPicture(openFileDialog.FileName);
            }
        }
        
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        
        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Simple Paint. The program opens and saves files in JSON format." +
                            "It is used for simple painting manipulation tasks.\n" +
                            "Made by Nemiro Maxim. 2020");
        }

        private void SaveFileProcess()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Json File(*.json) | *json";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (saveFileDialog.ShowDialog() == true)
            {
                graphicRedactor.SavePicture(saveFileDialog.FileName);
            }
        }

        #endregion
    }
}