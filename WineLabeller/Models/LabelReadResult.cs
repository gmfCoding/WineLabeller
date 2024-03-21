using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineLabeller.Models
{
    public class LabelReadResult
    {
        public class BoundingPolygon
        {
            public int X { get; set; }
            public int Y { get; set; }

            public override string ToString()
            {
                return $"({X}, {Y})";
            }
        }

        public class Word
        {
            public string Text { get; set; }
            public List<BoundingPolygon> BoundingPolygon { get; set; }
            public double Confidence { get; set; }
        }

        public class Line
        {


            public string Text { get; set; }
            public List<BoundingPolygon> BoundingPolygon { get; set; }
            public List<Word> Words { get; set; }
        }

        public class Block
        {
            public List<Line> Lines { get; set; }
        }

        public List<Block> Blocks { get; set; }

        public LabelReadResult()
        {

        }
    }
}
