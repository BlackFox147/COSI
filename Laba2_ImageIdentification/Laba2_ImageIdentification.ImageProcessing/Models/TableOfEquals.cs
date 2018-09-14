using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2_ImageIdentification.ImageProcessing.Models
{
    public class TableOfEquals
    {
        public List<int> Equals { get; set; }

        public TableOfEquals()
        {
            Equals = new List<int>();
        }

        public TableOfEquals(List<int> areas)
        {
            Equals = new List<int>(areas);
        }

        public bool Contains(int area)
        {
            return Equals.Contains(area);
        }

        public bool ContainsInOne(int areaB, int areaC)
        {
            return Equals.Contains(areaB) && Equals.Contains(areaC);
        }
    }
}
