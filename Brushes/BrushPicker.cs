using System;
using System.Collections.Generic;

namespace VectorGraphicRedactor
{
    public static class BrushPicker
    {
        public static readonly List<ICustomBrush> BrushTools = new List<ICustomBrush> {new SolidBrushTool()};
        private static ICustomBrush brushTool = BrushTools[0];
        
        public static void SetBrushTool(ICustomBrush tool)
        {
            brushTool = tool;
        }

        public static void AddBrushTool(ICustomBrush tool)
        {
            BrushTools.Add(tool);
        }
        
        public static ICustomBrush GetBrushTool()
        {
            return brushTool;
        }
    }
}