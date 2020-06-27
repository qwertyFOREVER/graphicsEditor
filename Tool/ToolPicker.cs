using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace VectorGraphicRedactor
{
    public class ToolPicker
    {
        private readonly List<(Tool, Type)> tools;
        private (Tool, Type) tool;

        public ToolPicker()
        {
            tools = new List<(Tool, Type)>();
        }
        
        private void SetTool((Tool, Type) tool)
        {
            this.tool = tool;
        }

        public void AddTool(Tool tool)
        {
            tools.Add((tool, tool.GetType()));
        }
        
        public Tool GetTool()
        {
            return tool.Item1;
        }
        
        public void SetView(Panel toolPanel, Panel configPanel)
        {
            toolPanel.Children.Clear();

            tool = tools[0];
            
            foreach (var tool in tools)
            {
                var button = tool.Item1.ToolView;
                
                button.AddHandler(Button.ClickEvent, new RoutedEventHandler((o, e) =>
                {
                    SetTool(tool);
                    SetConfigs(configPanel);
                }));
                toolPanel.Children.Add(button);
            }
            
            SetConfigs(configPanel);
        }

        private void SetConfigs(Panel configPanel)
        {
            configPanel.Children.Clear();
            
            var properties = tool.Item2.GetProperties();
            
            foreach (var property in properties)
            {
                if (property.PropertyType.IsSubclassOf(typeof(Config)))
                {
                    configPanel.Children.Add((property.GetValue(tool.Item1) as Config)?.View);
                }
            }
        }
    }
}