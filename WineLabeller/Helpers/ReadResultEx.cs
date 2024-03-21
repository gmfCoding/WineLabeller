using Azure.AI.Vision.ImageAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WineLabeller.Models;

namespace WineLabeller.Helpers
{
    public static class ReadResultEx
    {
        public static List<LabelReadResult.BoundingPolygon> BoundPloygonsFromImagePoints(IReadOnlyList<ImagePoint> points)
        {
            List<LabelReadResult.BoundingPolygon> polygons = new List<LabelReadResult.BoundingPolygon>();

            foreach (var bound in points)
            {
                polygons.Add(new LabelReadResult.BoundingPolygon() { X = bound.X, Y = bound.Y });
            }
            return polygons;
        }
        public static LabelReadResult ToLabelReadResult(this ReadResult res)
        {
            // It would probably be easier to use Json to convert between them.
            // ReadResult -> JsonSerializer -> Json -> JsonDeserializer -> LabelReadResult

            LabelReadResult label = new LabelReadResult();
            if (res == null)
                return label;
            foreach (DetectedTextBlock block in res.Blocks)
            {
                LabelReadResult.Block labelBlock = new LabelReadResult.Block();
                foreach (DetectedTextLine line in block.Lines)
                {
                    LabelReadResult.Line labelLine = new LabelReadResult.Line();
                    labelLine.BoundingPolygon = BoundPloygonsFromImagePoints(line.BoundingPolygon);
                    foreach (DetectedTextWord word in line.Words)
                    {
                        LabelReadResult.Word insert = new LabelReadResult.Word();
                        insert.BoundingPolygon = BoundPloygonsFromImagePoints(word.BoundingPolygon);
                        insert.Text = word.Text;
                        labelLine.Words.Add(insert);
                    }
                    labelBlock.Lines.Add(labelLine);
                }
                label.Blocks.Add(labelBlock);
            }
            return label;
        }
    }
}
