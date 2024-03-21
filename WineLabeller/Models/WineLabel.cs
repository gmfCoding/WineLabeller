using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WineLabeller.Models
{
    public class WineLabel
    {
        public string Brand { get; private set; }
        public string Location { get; private set; }
        public string Alcohol { get; private set; }
        public string Variety { get; private set; }
        public string Volume { get; private set; }
    }
}
